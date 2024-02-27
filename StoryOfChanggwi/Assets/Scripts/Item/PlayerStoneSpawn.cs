using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStoneSpawn : MonoBehaviour
{
    // 봉인석 위치 리스트
    [SerializeField] List<GameObject> playerStoneLocation;
    // 활성화된 봉인석 리스트
    List<int> activePlayerStoneList = new List<int>();
    // Invoke bool
    bool invokeStart;


    void Start()
    {
        // 시작할 때 봉인석 전부 비활성화
        foreach (GameObject playerstone in playerStoneLocation)
        {
            playerstone.SetActive(false);
        }
        // 랜덤 함수로 봉인석 5개 활성화
        CreateRandomNum(10, 5);

        // Invoke 실행
        invokeStart = true;
        InvokeRepeating("StartSpawning", 10f, 10f);
    }

    private void Update()
    {   
        // Invoke가 중단된 상태이고 활성화된 봉인석 리스트 크기가 최대 봉인석 개수보다 적을 때
        // 봉인석 소환 반복 시작
        if(activePlayerStoneList.Count < playerStoneLocation.Count && invokeStart == false)
        {
            invokeStart = true;
            Debug.Log("봉인석 소환 반복 시작");
            InvokeRepeating("StartSpawning", 10f, 10f);
        }
        
    }

    // 획득한 봉인석 활성화된 봉인석 리스트에서 제거
    public void FindStone(GameObject gameObject)
    {
        int index = playerStoneLocation.IndexOf(gameObject);
        activePlayerStoneList.Remove(index);
        //Debug.Log(index);
    }

    // 봉인석 2개씩 소환
    void StartSpawning()
    {
        if(activePlayerStoneList.Count + 2 <= playerStoneLocation.Count)
        {
            CreateRandomNum(10, 2);
        }
        else
        {
            CreateRandomNum(10, 1);
        }

        // 활성화된 봉인석 리스트 크기가 봉인석 최대 개수보다 같거나 커지면 Invoke 중단
        if (activePlayerStoneList.Count >= playerStoneLocation.Count)
        {
            Debug.Log("봉인석 소환 반복 중단");
            CancelInvoke();
            invokeStart = false;
        }

    }

    // 봉인석 소환 랜덤 함수
    void CreateRandomNum(int max, int cnt)
    {
        int currentNumber = Random.Range(0, max);

        for(int i = 0; i < cnt;)
        {
            // 활성화된 봉인석 리스트에 이미 있으면 다시 랜덤 지정
            if(activePlayerStoneList.Contains(currentNumber))
            {
                currentNumber = Random.Range(0, max);
            }
            else
            {
                activePlayerStoneList.Add(currentNumber);
                playerStoneLocation[currentNumber].SetActive(true);
                Debug.Log(currentNumber);
                i++;
            }
        }
    }
    
}
