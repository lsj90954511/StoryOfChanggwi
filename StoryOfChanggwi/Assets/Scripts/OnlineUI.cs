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

    //�� ����� ��ư ������ ��
    public void OnClickCreateRoomButton()
    {
        //�г��� �ԷµǾ� ���� ��� �� ������ �Ѿ
        if(nicknameInputField.text != "")
        {
            createRoomUI.SetActive(true);
            gameObject.SetActive(false);
        }
        //�г��� �Էµ��� �ʾ��� ��� �г����� �͸����� �����ϰ� �� ������ �Ѿ
        else
        {
            nicknameInputField.text = "�͸�";
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
