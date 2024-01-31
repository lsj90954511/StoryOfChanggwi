using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneManager : MonoBehaviour
{
    public Stone[] stones;
    public List<Stone> fieldStones;

    // Start is called before the first frame update
    void Start()
    {
        GetStone();
    }

    // Update is called once per frame
    void Update()
    {

    }

    // 모델 오브젝트 연결
    private void GetStone()
    {
        // 모델 오브젝트 가져오기
        stones = GetComponentsInChildren<Stone>();  
    }

    public void SetStones(int _cCount)
    {
        // 봉인석 비활성화
        for (int i = 0; i < stones.Length; i++)
        {
            stones[i].gameObject.SetActive(false);
        }

        // 봉인석 활성화
        for (int i = 0; i < _cCount; i++)
        {
            // 추후 랜덤으로 변경
            stones[i].gameObject.SetActive(true);
            fieldStones.Add(stones[i]);
        }
    }
}
