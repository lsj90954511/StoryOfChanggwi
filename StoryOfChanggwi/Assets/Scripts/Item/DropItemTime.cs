using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropItemTime : MonoBehaviour
{
    float ttl = 300f; //시간 경과
    PlayerStoneSpawn playerStoneSpawn;

    // Start is called before the first frame update
    void Awake()
    {
        playerStoneSpawn = FindObjectOfType<PlayerStoneSpawn>();
    }

    // Update is called once per frame
    void Update()
    {
        ttl -= Time.deltaTime;
        if (ttl < 0) //아이템 미습득 상태로 ttl만큼 경과시 아이템삭제
        {
            playerStoneSpawn.FindStone(this.gameObject);
            gameObject.SetActive(false);
            Debug.Log("아이템 사라짐");
            ttl = 10f;
        }
    }
}
