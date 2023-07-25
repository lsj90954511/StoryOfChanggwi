using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Mirror;

public class OnlineUI : MonoBehaviour
{
    [SerializeField]
    private TMP_InputField nicknameInputField;
    [SerializeField]
    private GameObject createRoomUI;

    //방 만들기 버튼 눌렀을 때
    public void OnClickCreateRoomButton()
    {
        //닉네임 입력되어 있을 경우 방 만들기로 넘어감
        if(nicknameInputField.text != "")
        {
            createRoomUI.SetActive(true);
            gameObject.SetActive(false);
        }
        //닉네임 입력되지 않았을 경우 닉네임을 익명으로 설정하고 방 만들기로 넘어감
        else
        {
            nicknameInputField.text = "익명";
            createRoomUI.SetActive(true);
            gameObject.SetActive(false);
        }
        PlayerSettings.nickname = nicknameInputField.text;
    }

    public void OnClickEnterGameRoomButton()
    {
        if (nicknameInputField.text != "")
        {
            var manager = RoomManager.singleton;
            manager.StartClient();
        }
        else
        {
            nicknameInputField.text = "�͸�";
        }
    }
}
