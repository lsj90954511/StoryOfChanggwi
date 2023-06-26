using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;

public class PhotonManager : MonoBehaviourPunCallbacks
{
    private bool connect = false;
 
    //서버 연결
    public void Connect() => PhotonNetwork.ConnectUsingSettings();

    //서버 연결 시 호출
    public override void OnConnectedToMaster()
    {
        print("서버접속완료");
        connect = true;
    }

    //서버 연결 끊기
    public void Disconnect() => PhotonNetwork.Disconnect();

    //서버 연결 끊겼을 시 호출
    public override void OnDisconnected(DisconnectCause cause) => print("연결끊김");

    private void Awake()
    {
        Connect();
    }

}
