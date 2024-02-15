using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStoneSpawn : MonoBehaviour
{
    [SerializeField] List<GameObject> playerStoneLocation;
    List<int> activePlayerStoneList = new List<int>();
    bool invokeStart;


    void Start()
    {
        foreach (GameObject playerstone in playerStoneLocation)
        {
            playerstone.SetActive(false);
        }
        CreateRandomNum(10, 5);
        for(int i = 0; i < activePlayerStoneList.Count; i++)
        {
            playerStoneLocation[activePlayerStoneList[i]].SetActive(true);
            Debug.Log(activePlayerStoneList[i]);
        }
        invokeStart = true;
        InvokeRepeating("StartSpawning", 10f, 10f);
    }

    private void Update()
    {
        if(activePlayerStoneList.Count >= playerStoneLocation.Count)
        {
            Debug.Log("봉인석 소환 반복 중단");
            CancelInvoke();
            invokeStart = false;
        }
        if(invokeStart == false && activePlayerStoneList.Count > 0)
        {
            invokeStart = true;
            Debug.Log("봉인석 소환 반복 시작");
            InvokeRepeating("StartSpawning", 10f, 10f);
        }
    }

    public void FindStone(GameObject gameObject)
    {
        int index = playerStoneLocation.IndexOf(gameObject);
        activePlayerStoneList.Remove(index);
        Debug.Log(index);
    }

    void StartSpawning()
    {
        if(activePlayerStoneList.Count + 2 < 10)
        {
            CreateRandomNum(10, 2);
            playerStoneLocation[activePlayerStoneList[activePlayerStoneList.Count - 1]].SetActive(true);
            Debug.Log(activePlayerStoneList[activePlayerStoneList.Count - 1]);
            playerStoneLocation[activePlayerStoneList[activePlayerStoneList.Count - 2]].SetActive(true);
            Debug.Log(activePlayerStoneList[activePlayerStoneList.Count - 2]);
        }
        else
        {
            CreateRandomNum(10, 1);
            playerStoneLocation[activePlayerStoneList[activePlayerStoneList.Count - 1]].SetActive(true);
            Debug.Log(activePlayerStoneList[activePlayerStoneList.Count - 1]);
        }
        
    }

    void CreateRandomNum(int max, int cnt)
    {
        int currentNumber = Random.Range(0, max);

        for(int i = 0; i < cnt;)
        {
            if(activePlayerStoneList.Contains(currentNumber))
            {
                currentNumber = Random.Range(0, max);
            }
            else
            {
                activePlayerStoneList.Add(currentNumber);
                i++;
            }
        }
    }
    
}
