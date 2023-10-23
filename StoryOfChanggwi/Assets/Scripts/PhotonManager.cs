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
