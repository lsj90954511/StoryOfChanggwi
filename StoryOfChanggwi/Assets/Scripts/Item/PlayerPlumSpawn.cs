using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPlumSpawn : MonoBehaviour
{

    [SerializeField] List<GameObject> playerPlumLocation;
    List<int> activePlayerPlumList = new List<int>();
    // Start is called before the first frame update
    void Start()
    {
        foreach (GameObject playerplum in playerPlumLocation)
        {
            playerplum.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void FindPlum(GameObject gameObject)
    {
        int index = playerPlumLocation.IndexOf(gameObject);
        activePlayerPlumList.Remove(index);
        //Debug.Log(index);
    }

    void CreateRandomNum(int max, int cnt)
    {
        int currentNumber = Random.Range(0, max);

        for (int i = 0; i < cnt;)
        {
            if (activePlayerPlumList.Contains(currentNumber))
            {
                currentNumber = Random.Range(0, max);
            }
            else
            {
                activePlayerPlumList.Add(currentNumber);
                i++;
            }
        }
    }
}
