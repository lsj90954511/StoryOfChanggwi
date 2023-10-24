using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Photon.Pun;
using Photon.Realtime;

public class PhotonManager : MonoBehaviourPunCallbacks
{
    [SerializeField]
    private TMP_InputField nicknameInputField;
    [SerializeField]
    private TMP_InputField roomnameInputFieldI;
    [SerializeField]
    private GameObject createRoomUI;

    //룸 목록을 저장하는 딕셔너리 자료형
    private Dictionary<string, GameObject> roomDict = new Dictionary<string, GameObject>();
    //룸을 표시할 프리팹
    public GameObject roomPrefab;
    //룸 프리팹이 차일드화 시킬 부모 객체
    public Transform scrollContent;

    private void Awake()
    {
        //방장이 씬 로딩 시 나머지 사람들 자동 싱크
        PhotonNetwork.AutomaticallySyncScene = true;

        //서버 접속
        PhotonNetwork.ConnectUsingSettings();
    }

    void Start()
    {
        Debug.Log("00 . 포톤 매니저 시작");
        PhotonNetwork.LocalPlayer.NickName = nicknameInputField.text;
    }

    public override void OnConnectedToMaster()
    {
        Debug.Log("01. 포톤 서버에 접속");

        //로비에 접속
        PhotonNetwork.JoinLobby();
    }

    public override void OnJoinedLobby()
    {
        Debug.Log("02 . 로비에 접속");
    }

    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        Debug.Log("랜덤 룸 접속 실패");

        //방 생성 창 나옴
        createRoomUI.SetActive(true);
    }

    public override void OnCreatedRoom()
    {
        Debug.Log("03 . 방 생성 완료");
    }

    public override void OnJoinedRoom()
    {
        Debug.Log("04 . 방 입장 완료");
        if (PhotonNetwork.IsMasterClient)
        {
            PhotonNetwork.LoadLevel("GamePlay");
        }
    }

    public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {
        GameObject tempRoom = null;
        foreach (var room in roomList)
        {
            //룸이 삭제된 경우
            if (room.RemovedFromList == true)
            {
                roomDict.TryGetValue(room.Name, out tempRoom);
                Destroy(tempRoom);
                roomDict.Remove(room.Name);
            }
            //룸 정보가 변경된 경우
            else
            {
                //룸이 처음 생성된 경우
                if (roomDict.ContainsKey(room.Name) == false)
                {
                    GameObject _room = Instantiate(roomPrefab, scrollContent);
                    _room.GetComponent<RoomData>().RoomInfo = room;
                    roomDict.Add(room.Name, _room);
                }
                //룸 정보를 갱신하는 경우
                else
                {
                    roomDict.TryGetValue(room.Name, out tempRoom);
                    tempRoom.GetComponent<RoomData>().RoomInfo = room;
                }
            }
        }
    }

    public void OnRandomBtn()
    {
        //닉네임 비어 있을 경우
        if (nicknameInputField.text == "")
        {
            nicknameInputField.text = "익명";
        }

        //PlayerPrefs.SetString("USER_NICKNAME", nicknameInputField.text);
        PhotonNetwork.NickName = nicknameInputField.text;
        PhotonNetwork.JoinRandomRoom();
    }
}
