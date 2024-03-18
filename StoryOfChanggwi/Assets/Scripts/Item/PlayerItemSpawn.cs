using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerItemSpawn : MonoBehaviour
{
    // 주술재료 위치 리스트
    [SerializeField] List<GameObject> playerItemLocation;
    // 활성화된 주술재료 리스트
    List<int> activePlayerItemList = new List<int>();
    // Invoke bool
    bool invokeStart;


    void Start()
    {
        // 시작할 때 주술재료 전부 비활성화
        foreach (GameObject playeritem in playerItemLocation)
        {
            playeritem.SetActive(false);
        }
        // 랜덤 함수로 주술재료 5개 활성화
        CreateRandomNum(10, 5);

        // Invoke 실행
        invokeStart = true;
        InvokeRepeating("StartSpawning", 10f, 10f);
    }

    private void Update()
    {   
        // Invoke가 중단된 상태이고 활성화된 주술재료 리스트 크기가 최대 주술재료 개수보다 적을 때
        // 주술재료 소환 반복 시작
        if(activePlayerItemList.Count < playerItemLocation.Count && invokeStart == false)
        {
            invokeStart = true;
            Debug.Log("주술 재료 반복 시작");
            InvokeRepeating("StartSpawning", 10f, 10f);
        }
        
    }

    // 획득한 주술재료 활성화된 주술재료 리스트에서 제거
    public void FindStone(GameObject gameObject)
    {
        int index = playerItemLocation.IndexOf(gameObject);
        activePlayerItemList.Remove(index);
        //Debug.Log(index);
    }

    // 주술재료 2개씩 소환
    void StartSpawning()
    {
        if(activePlayerItemList.Count + 2 <= playerItemLocation.Count)
        {
            CreateRandomNum(10, 2);
        }
        else
        {
            CreateRandomNum(10, 1);
        }

        // 활성화된 주술재료 리스트 크기가 주술재료 최대 개수보다 같거나 커지면 Invoke 중단
        if (activePlayerItemList.Count >= playerItemLocation.Count)
        {
            Debug.Log("봉인석 소환 반복 중단");
            CancelInvoke();
            invokeStart = false;
        }

    }

    // 주술재료 소환 랜덤 함수
    void CreateRandomNum(int max, int cnt)
    {
        int currentNumber = Random.Range(0, max);

        for(int i = 0; i < cnt;)
        {
            // 활성화된 주술재료 리스트에 이미 있으면 다시 랜덤 지정
            if(activePlayerItemList.Contains(currentNumber))
            {
                currentNumber = Random.Range(0, max);
            }
            else
            {
                activePlayerItemList.Add(currentNumber);
                playerItemLocation[currentNumber].SetActive(true);
                Debug.Log(currentNumber);
                i++;
            }
        }
    }
    
}
