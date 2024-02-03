using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneManager : MonoBehaviour
{
    public Transform[] stoneLocation;
    public List<Stone> stones;

    // State
    private int activeCount;
    public int citizenCount;

    public GameObject stonePrefab;

    void Start()
    {
        activeCount = 0;
        CreateStone(citizenCount);
    }

    void Update()
    {

    }

    // Create Stones in random location
    private void CreateStone(int _count)
    {
        // Get Stone's Location
        stoneLocation = GetComponentsInChildren<Transform>();

        // Get World Canvas
        Transform canvas = GameObject.Find("WorldCanvas").transform;

        // Get Stone Prefab
        stonePrefab = transform.GetChild(0).gameObject;

        // Get Random Location
        int[] rand = new int[_count];
        int idx, cnt = 0;

        cnt = 0;
        while (cnt < _count)
        {
            int r = Random.Range(0, stoneLocation.Length);
            for (idx = 0; idx < cnt; idx++)
                if (rand[idx] == r) break;
            if (cnt == idx) rand[cnt++] = r;
        }
        System.Array.Sort(rand);

        // Create Stone
        for (int i = 0; i < _count; i++)
        {
            Stone stone = Instantiate(stonePrefab, transform).GetComponent<Stone>();
            stone.transform.position = stoneLocation[rand[i]].position;
            stone.ConnectUI(canvas);
            stone.sManager = this;

            stones.Add(stone);
        }

        // Deactivate Stone Prefab
        stonePrefab.SetActive(false);
    }

    public void StartSetting(int _cCount)
    {
        //// Deactivate Stone
        //for (int i = 0; i < stones.Length; i++)
        //{
        //    stones[i].gameObject.SetActive(false);
        //}

        //// 봉인석 활성화
        //for (int i = 0; i < _cCount; i++)
        //{
        //    // 추후 랜덤으로 변경
        //    stones[i].gameObject.SetActive(true);
        //    fieldStones.Add(stones[i]);
        //}
    }

    public void UpdateStone(bool _isActive)
    {
        if (_isActive)
            activeCount++;
        else
            activeCount--;

        if(activeCount == citizenCount)
        {
            // Win
            print("승리");
        }
    }
}
