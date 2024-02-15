using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Photon.Pun;
using Photon.Realtime;

public class LobbyManager : MonoBehaviourPunCallbacks
{
    [SerializeField]
    private GameObject startBtn;
    [SerializeField]
    private GameObject lobbyUI;
    [SerializeField]
    private TMP_Text startMessage;
    [SerializeField]
    private List<Image> imgs;
    [SerializeField]
    private List<TMP_Text> names;
    [SerializeField]
    private Sprite[] sprites;

    private PhotonView PV;

    float timer;
    bool started = false, showedMessage = false; //게임 시작 버튼이 눌렸는 지 확인, Start 메시지를 보여줬는 지 확인

    bool Master()
    {
        return PhotonNetwork.LocalPlayer.IsMasterClient;
    }


    void Start()
    {
        PV = GetComponent<PhotonView>();

        timer = 0.0f;

        //마스터 플레이어에게만 시작 버튼 보이게 함
        if (Master() && PV.IsMine == true) startBtn.SetActive(true);

        PV.RPC("SetPlayer", RpcTarget.AllViaServer);
    }

    void Update()
    {
        if (started)
        {
            /*startMessage.text = "Start";

            timer += Time.deltaTime;
            if (timer >= 5.0f)
            {
                startMessage.text = "";
                started = false;
            }*/
            PV.RPC("ShowStartMessage", RpcTarget.AllViaServer);

            timer += Time.deltaTime;
            if (timer >= 1.5f)
            {
                startMessage.text = "";
                started = false;
                showedMessage = true;
            }
        }
        if (!started && showedMessage)
        {
            
            PV.RPC("StartGame", RpcTarget.AllViaServer);
        }
        //playerUpdate();
    }

    public void ClickStartBtn()
    {
        started = true;
    }

    public void playerUpdate()
    {
        for (int i = 0; i < PhotonNetwork.CurrentRoom.PlayerCount; i++)
        {
            //닉네임 세팅
            names[i].text = PhotonNetwork.PlayerList[i].NickName;
            //이미지 세팅
            int index = Random.Range(0, sprites.Length);
            Sprite select = sprites[index];
            imgs[i].sprite = select;
        }
    }

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        PV.RPC("SetPlayer", RpcTarget.AllViaServer);
    }

    //Start라는 텍스트를 화면에 보여줌
    [PunRPC]
    public void ShowStartMessage()
    {
        startMessage.text = "Start";

    }

    //로비 패널을 비활성화
    [PunRPC]
    public void StartGame()
    {
        lobbyUI.SetActive(false);
    }

    //로비에 플레이어 세팅
    [PunRPC]
    public void SetPlayer()
    {
        for (int i = 0; i < PhotonNetwork.CurrentRoom.PlayerCount; i++)
        {
            if (names[i].text == "" && imgs[i].sprite == sprites[0])
            {
                //닉네임 세팅
                names[i].text = PhotonNetwork.PlayerList[i].NickName;
                //이미지 세팅
                int index = Random.Range(1, sprites.Length);
                Sprite select = sprites[index];
                imgs[i].sprite = select;
            }
        }
    }
}
