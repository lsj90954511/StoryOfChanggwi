using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStoneSpawn : MonoBehaviour
{
    [SerializeField] List<GameObject> playerStoneLocation;
    List<int> activePlayerStoneList = new List<int>();
    // Start is called before the first frame update
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

    }

    void StartSpawning()
    {

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
