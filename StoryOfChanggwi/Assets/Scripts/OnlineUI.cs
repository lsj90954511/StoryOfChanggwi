using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Photon.Pun;
using Photon.Realtime;

public class OnlineUI : MonoBehaviour
{
    [SerializeField]
    private GameObject createRoomUI;
    [SerializeField]
    private TMP_InputField nicknameInputField;

    public void awake()
    {
        createRoomUI.SetActive(false);
    }

    //방 만들기 버튼 눌렀을 때
    public void OnClickCreateRoomButton()
    {
        createRoomUI.SetActive(true);
    }

    public void NicknameSet()
    {
        PhotonNetwork.LocalPlayer.NickName = nicknameInputField.text;
    }
}
