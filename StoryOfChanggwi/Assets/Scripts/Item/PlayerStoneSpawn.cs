using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStoneSpawn : MonoBehaviour
{
    [SerializeField] List<GameObject> playerStoneLocation;
    public List<int> activePlayerStoneList;
    // Start is called before the first frame update
    void Start()
    {
        foreach (GameObject playerstone in playerStoneLocation)
        {
            playerstone.SetActive(false);
        }
        
    }

    void StartSpawning()
    {

    }

    void CreateRandomNum(int max)
    {
        int currentNumber = Random.Range(0, max);

        for(int i = 0; i < max;)
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
