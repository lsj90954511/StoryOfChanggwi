using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRole : MonoBehaviour
{
    public enum Role
    {
        changgui,
        woodman,
        bobusang,
        seonbi,
        monk,
        anagne,
        changgui_tiger,
        //ghost,
    }

    private const int roleCount = 8;


    public Role role;
    private int roleNum;

    public GameObject[] rModel;

    // Start is called before the first frame update
    void Start()
    {
        GetModel();

        // 모델 활성화
        ChangeRole(0);
    }

    private void Update()
    {

        if((int)role != roleNum)
        {
            RoleSetting();
        }
    }

    // 역할 변경
    public void ChangeRole(int _rNum)
    {
        role = (Role)_rNum;
        RoleSetting();
    }
    public void ChangeRole(Role _role)
    {
        role = _role;
        RoleSetting();
    }

    // 시민으로 역할 변경
    public void ChangeToCitizen()
    {
        int rand = Random.Range(3, roleCount);
        ChangeRole(rand);
    }

    // 역할 변경 세팅
    private void RoleSetting()
    {
        roleNum = (int)role;

        // 역할 활성화
        SetModel(roleNum);
    }

    // 모델 오브젝트 연결
    private void GetModel()
    {
        // 모델 오브젝트 가져오기
        rModel = new GameObject[transform.childCount];

        for(int i = 0; i < transform.childCount; i++)
        {
            rModel[i] = transform.GetChild(i).gameObject;
        }
    }

    // 모델 오브젝트 변경
    private void SetModel(int _rNum)
    {
        // 역할모델 활성화
        for(int i = 0; i < rModel.Length; i++)
        {
            rModel[i].gameObject.SetActive(false);
        }
        rModel[_rNum].gameObject.SetActive(true);

        // 플레이어 동작 스크립트에 모델 컴포넌트 연결
        GetComponentInParent<PlayerControl>().SetModel(rModel[_rNum]);
    }
}
