using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;

public class PhotonManager : MonoBehaviourPunCallbacks
{
    private bool connect = false;
 
    //���� ����
    public void Connect() => PhotonNetwork.ConnectUsingSettings();

    //���� ���� �� ȣ��
    public override void OnConnectedToMaster()
    {
        print("�������ӿϷ�");
        connect = true;
    }

    //���� ���� ����
    public void Disconnect() => PhotonNetwork.Disconnect();

    //���� ���� ������ �� ȣ��
    public override void OnDisconnected(DisconnectCause cause) => print("�������");

    private void Awake()
    {
        Connect();
    }

}
