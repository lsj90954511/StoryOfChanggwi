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
        //������ �� �ε� �� ������ ����� �ڵ� ��ũ
        PhotonNetwork.AutomaticallySyncScene = true;

        //���� ����
        PhotonNetwork.ConnectUsingSettings();
    }

    void Start()
    {
        Debug.Log("00 . ���� �Ŵ��� ����");
        PhotonNetwork.LocalPlayer.NickName = nicknameInputField.text;
    }

    public override void OnConnectedToMaster()
    {
        Debug.Log("01. ���� ������ ����");

        //�κ� ����
        PhotonNetwork.JoinLobby();
    }

    public override void OnJoinedLobby()
    {
        Debug.Log("02 . �κ� ����");
    }

    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        Debug.Log("���� �� ���� ����");

        //�� ���� â ����
        createRoomUI.SetActive(true);
    }

    public override void OnCreatedRoom()
    {
        Debug.Log("03 . �� ���� �Ϸ�");
    }

    public override void OnJoinedRoom()
    {
        Debug.Log("04 . �� ���� �Ϸ�");
        if (PhotonNetwork.IsMasterClient)
        {
            PhotonNetwork.LoadLevel("GamePlay");
        }
    }

    public void OnRandomBtn()
    {
        //�г��� ��� ���� ���
        if (nicknameInputField.text == "")
        {
            nicknameInputField.text = "�͸�";
        }

        //PlayerPrefs.SetString("USER_NICKNAME", nicknameInputField.text);
        PhotonNetwork.NickName = nicknameInputField.text;
        PhotonNetwork.JoinRandomRoom();
    }
}
