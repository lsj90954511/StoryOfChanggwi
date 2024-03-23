using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;
using System;

public class Wander : MonoBehaviour
{
    public float pursuitSpeed; //추적 시 속도
    public float wanderSpeed; //평상시 속도
    public float currentSpeed; //위 둘 중 현재 속도

    public float directionChangeInterval;
    public bool followPlayer;
    private SpriteRenderer sprite;

    Coroutine moveCoroutine;
    CircleCollider2D CircleCollider2D;
    Rigidbody2D rb2d;
    Animator animator;
    private PhotonView pv;

    Transform targetTransform = null;
    Vector3 endPosition;
    float currentAngle = 0;

    private int hp; //hp
    [SerializeField] private Slider hpBar;

    public int Hp
    {
        get => hp;
        private set => hp = Math.Clamp(value, 0, hp);
    }

    private void Awake()
    {
        hp = 100;
        SetMaxHealth(hp);
        pv = GetComponent<PhotonView>();
        sprite = GetComponentInChildren<SpriteRenderer>();
    }

    public void SetMaxHealth(int health)
    {
        hpBar.maxValue = health;
        hpBar.value = health;
    }

    //hp깎임.
    public void GetDamage(int damage)
    {
        int getDamagedHp = Hp - damage;
        Hp = getDamagedHp;
        hpBar.value = Hp;
    }

    //hp 확인
    public int getHp()
    {
        return Hp;
    }

    void Start()
    {
        animator = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();
        CircleCollider2D = GetComponent<CircleCollider2D>();
        currentSpeed = wanderSpeed;
        StartCoroutine(WanderRoutine());
        sprite = GetComponentInChildren<SpriteRenderer>();
    }

    void Update()
    {
        Debug.DrawLine(rb2d.position, endPosition, Color.red);
        if (Hp <= 0)
        {
            gameObject.SetActive(false);
        }
    }

    public IEnumerator WanderRoutine()
    {
        while (true)
        {
            ChooseNewEndPoint();

            if (moveCoroutine != null)
            {
                StopCoroutine(moveCoroutine);
            }
            moveCoroutine = StartCoroutine(Move(rb2d, currentSpeed));

            yield return new WaitForSeconds(directionChangeInterval);
        }
    }

    void ChooseNewEndPoint()
    {
        currentAngle += UnityEngine.Random.Range(0, 360);
        currentAngle = Mathf.Repeat(currentAngle, 360);
        endPosition += Vector3FromAngle(currentAngle);
    }

    Vector3 Vector3FromAngle(float inputAngleDegrees)
    {
        float inputAngleRadians = inputAngleDegrees * Mathf.Deg2Rad;

        return new Vector3(Mathf.Cos(inputAngleRadians), Mathf.Sin(inputAngleRadians), 0);
    }

    public IEnumerator Move(Rigidbody2D rigidbodyToMove, float speed)
    {
        float remainingDistance = (transform.position - endPosition).sqrMagnitude;

        while(remainingDistance > float.Epsilon)
        {
            if (targetTransform != null)
            {
                endPosition = targetTransform.position;
            }

            if (rigidbodyToMove != null)
            {
                animator.SetBool("IsWalk", true);
                Vector3 newPosition = Vector3.MoveTowards(rigidbodyToMove.position, endPosition, speed * Time.deltaTime);

                // 방향 전환
                if (transform.position.x - newPosition.x < 0)
                    pv.RPC("FlipXRPC", RpcTarget.AllBuffered, newPosition);
                else if (transform.position.x - newPosition.x > 0)
                    pv.RPC("FlipXRPC", RpcTarget.AllBuffered, newPosition);

                rb2d.MovePosition(newPosition);
                remainingDistance = (transform.position - endPosition).sqrMagnitude;
            }
            yield return new WaitForFixedUpdate();
        }
        animator.SetBool("IsWalk", false);
    }

    [PunRPC]
    void FlipXRPC(Vector3 newPosition)
    {
        sprite.flipX = transform.position.x - newPosition.x < 0;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && followPlayer)
        {
            currentSpeed = pursuitSpeed;
            targetTransform = collision.gameObject.transform;
            if (moveCoroutine != null)
            {
                StopCoroutine(moveCoroutine);
            }

            moveCoroutine = StartCoroutine(Move(rb2d, currentSpeed));
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            animator.SetBool("IsWalk", false);
            currentSpeed = wanderSpeed;

            if (moveCoroutine != null)
            {
                StopCoroutine(moveCoroutine);
            }
            targetTransform = null;
        }
    }

    void OnDrawGizmos()
    {
        if (CircleCollider2D != null)
        {
            Gizmos.DrawWireSphere(transform.position, CircleCollider2D.radius);
        }
    }
}
