using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;
using TMPro;

public class CreateRoomUI : MonoBehaviour
{
    [SerializeField]
    private List<Button> changgwiCountButtons;

    [SerializeField]
    private List<Button> personCountButtons;

    [SerializeField]
    private List<Button> stoneCountButtons;

    [SerializeField]
    private TMP_InputField roomnameInputField;

    private CreateGameRoomData roomData;

    void Start()
    {
        //roomnameInputField = GameObject.Find("RoomName").GetComponent<TMP_InputField>();

        //방 데이터 기본 세팅
        roomData = new CreateGameRoomData() { roomname = "창귀뎐", changgwiCount = 2, personCount = 5, stoneCount = 5 };
    }

    //창귀 수 선택 시
    public void UpdateChanggwiCount(int count)
    {
        roomData.changgwiCount = count;

        //해당 버튼의 테두리 보이게 함.(추후 테두리 이미지 추가해야함)
        for(int i = 0; i < changgwiCountButtons.Count; i++)
        {
            if (i == count - 1)
            {
                changgwiCountButtons[i].image.color = new Color(1f, 1f, 1f, 1f);
            }
            else
            {
                changgwiCountButtons[i].image.color = new Color(1f, 1f, 1f, 0f);
            }
        }
    }

    //주민 수 선택 시
    public void UpdatePersonCount(int count)
    {
        roomData.personCount = count;

        //해당 버튼의 테두리 보이게 함.(추후 테두리 이미지 추가해야함)
        for (int i = 0; i < personCountButtons.Count; i++)
        {
            if (i == count - 1)
            {
                personCountButtons[i].image.color = new Color(1f, 1f, 1f, 1f);
            }
            else
            {
                personCountButtons[i].image.color = new Color(1f, 1f, 1f, 0f);
            }
        }
    }

    //봉인석 수 선택 시
    public void UpdateStoneCount(int count)
    {
        roomData.stoneCount = count;

        //해당 버튼의 테두리 보이게 함.(추후 테두리 이미지 추가해야함)
        for (int i = 0; i < stoneCountButtons.Count; i++)
        {
            if (i == count - 1)
            {
                stoneCountButtons[i].image.color = new Color(1f, 1f, 1f, 1f);
            }
            else
            {
                stoneCountButtons[i].image.color = new Color(1f, 1f, 1f, 0f);
            }
        }
    }

    public void UpdateRoomName()
    {
        roomData.roomname = roomnameInputField.text;
    }

    public void CreateRoom()
    {
        //PhotonNetwork.JoinLobby();
        PhotonNetwork.CreateRoom(roomData.roomname, new RoomOptions { MaxPlayers = roomData.changgwiCount + roomData.personCount + roomData.stoneCount }, null);
    }
}

//새로 만드는 방의 데이터 저장, 만들어지는 방에 데이터 전달
public class CreateGameRoomData
{
    public string roomname; //방 이름
    public int changgwiCount; //창귀 수
    public int personCount; //주민 수
    public int stoneCount; //봉인석 수
}