using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;


public class PlayerControl : MonoBehaviour
{
    private PhotonView pv;

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
    private void Awake()
    {
        pv = GetComponent<PhotonView>();

        rb = GetComponentInChildren<Rigidbody2D>();
        sprite = GetComponentInChildren<SpriteRenderer>();
    }

    private void Update()
    {
        // 움직임 입력
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        // 방향 전환
        if (movement.x > 0 && !sprite.flipX)
            sprite.flipX = true;
        else if (movement.x < 0 && sprite.flipX)
            sprite.flipX = false;

        // 애니메이션 전환
        if (movement.magnitude > 0 && !animator.GetBool("IsWalk"))
            animator.SetBool("IsWalk", true);
        else if (movement.magnitude == 0 && animator.GetBool("IsWalk"))
            animator.SetBool("IsWalk", false);

        // 아이템 사용
        if (Input.GetKeyUp(KeyCode.Space))
        {
            // 추가
        }

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
}