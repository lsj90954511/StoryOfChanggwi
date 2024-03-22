using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;
using TMPro;
using Cinemachine;

public class PlayerControl : MonoBehaviour
{
    private PhotonView pv;
    public TMP_Text NicknameText;
    GameObject manager;

    // 플레이어 움직임
    public float moveSpeed = 5.0f;

    // 컴포넌트
    public GameObject player;
    private Rigidbody2D rb;
    private SpriteRenderer sprite;
    private Animator animator;
    private Vector2 movement;

    // 봉인석
    private Coroutine stoneCo;

    //파티클
    //public ParticleSystem deathEffect;

    private void Awake()
    {
        pv = GetComponent<PhotonView>();
        animator = GetComponent<Animator>();
        rb = GetComponentInChildren<Rigidbody2D>();
        sprite = GetComponentInChildren<SpriteRenderer>();
        manager = GameObject.Find("GameManager");

        //닉네임
        NicknameText.text = pv.IsMine ? PhotonNetwork.NickName : pv.Owner.NickName;
        NicknameText.color = pv.IsMine ? Color.green : Color.red;

        if (pv.IsMine)
        {
            var CM = GameObject.Find("CMCamera").GetComponent<CinemachineVirtualCamera>();
            CM.Follow = transform;
            CM.LookAt = transform;
        }
    }

    private void Update()
    {
        if (!pv.IsMine && PhotonNetwork.IsConnected)
            return;

        // 움직임 입력
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        float axis_x = Input.GetAxisRaw("Horizontal");
        float axis_y = Input.GetAxisRaw("Vertical");

        // 방향 전환
        if (axis_x != 0 || axis_y != 0)
        {
            if (axis_x != 0)
                pv.RPC("FlipXRPC", RpcTarget.AllBuffered, axis_x);
            animator.SetBool("IsWalk", true); //애니메이션
        }
        else
            animator.SetBool("IsWalk", false);
    }

    //방향 전환 RPC 함수
    [PunRPC]
    void FlipXRPC(float axis)
    {
        sprite.flipX = axis == 1;
    }

    private void FixedUpdate()
    {
        // 움직임 적용
        rb.MovePosition(rb.position + movement.normalized * moveSpeed * Time.fixedDeltaTime);
    }

    public void SetModel(GameObject _model)
    {
        sprite = _model.GetComponent<SpriteRenderer>();
        animator = _model.GetComponent<Animator>();
    }

    // 스톤 활성화
    public void ActivateStone(Stone _stone)
    {
        // 봉인석 활성화
        if (Input.GetKeyDown(KeyCode.Z))
        {
            // 활성화
            _stone.Activate(1);
            print("플러스");
        }
        if (Input.GetKeyDown(KeyCode.X))
        {
            // 비활성화
            _stone.Activate(-1);
            print("마이너스");
        }
    }

    public void EnterStone(Stone _stone)
    {
        stoneCo = StartCoroutine(StoneCo(_stone));
    }
    public void ExitStone()
    {
        StopCoroutine(stoneCo);
    }

    public IEnumerator StoneCo(Stone _stone)
    {
        while (true)
        {
            ActivateStone(_stone);
            yield return null;
        }
    }

    //창귀와 충돌
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("충돌");
        GameObject obj = collision.gameObject;
        if (obj.CompareTag("Changgwi"))
        {
            pv.RPC("Attack", RpcTarget.All);
        }
    }

    [PunRPC]
    void Attack()
    {
        Debug.Log("어택 실행");
        //GetComponent<ParticleSystem>().Play();
        //Vector3 hitPoint = transform.position;
        //Destroy(Instantiate(deathEffect.gameObject, hitPoint, Quaternion.FromToRotation(Vector3.forward, hitPoint)), deathEffect.main.startLifetimeMultiplier);
        manager.GetComponent<GameManager>().PlayerDead(gameObject);
    }
}