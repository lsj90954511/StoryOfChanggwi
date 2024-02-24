using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Photon.Pun;
using Photon.Realtime;

public class NetworkManager : MonoBehaviourPunCallbacks
{
    [SerializeField]
    private TMP_InputField nicknameInputField;
    [SerializeField]
    private GameObject onlineUI;
    [SerializeField]
    private GameObject mainUI;

    public void Connect()
    {
        PhotonNetwork.ConnectUsingSettings();
        /*
        //닉네임 입력되지 않았을 경우 닉네임을 익명으로 설정
        if (nicknameInputField.text == "")
        {
            nicknameInputField.text = "익명";
        }*/
        PhotonNetwork.LocalPlayer.NickName = nicknameInputField.text;

        //OnlineUI로 넘어감
        onlineUI.SetActive(true);
        mainUI.SetActive(false);
    }

    //마스터 서버로 들어감
    public override void OnConnectedToMaster()
    {

    }
}
