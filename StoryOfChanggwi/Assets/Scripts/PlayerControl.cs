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
    private GameObject player;
    private Rigidbody2D rb;
    private SpriteRenderer sprite;
    private Vector2 movement;
    private Animator animator;

    private void Awake()
    {
        pv = GetComponent<PhotonView>();

        rb = GetComponentInChildren<Rigidbody2D>();
        sprite = GetComponentInChildren<SpriteRenderer>();
        animator = GetComponentInChildren<Animator>();
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
    }

    private void FixedUpdate()
    {
        // 움직임 적용
        rb.MovePosition(rb.position + movement.normalized * moveSpeed * Time.fixedDeltaTime);
    }
}