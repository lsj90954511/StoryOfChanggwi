using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class GameManager : MonoBehaviourPunCallbacks
{
    public static GameManager instance = null;

    public PhotonView pv;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else if (instance != this)
        {
            Destroy(this.gameObject);
        }
    }

    void Start()
    {
        pv = GetComponent<PhotonView>();
        if (PhotonNetwork.IsMasterClient)
            CreatePlayer();
    }

    void CreatePlayer()
    {
        //PhotonNetwork.Instantiate("Player", Vector2.zero, Quaternion.identity, 0);
        pv.RPC("CreatePlayerRPC", RpcTarget.AllBuffered);
    }

    [PunRPC]
    void CreatePlayerRPC()
    {
        PhotonNetwork.Instantiate("Player", Vector2.zero, Quaternion.identity, 0);
    }

    public void PlayerDead(GameObject player)
    {
        player.SetActive(false);
    }
}
