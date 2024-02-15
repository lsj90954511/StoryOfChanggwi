using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class GameManager : MonoBehaviour
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
        CreatePlayer();

        /*if (PhotonNetwork.IsMasterClient)
        {
            SelectChanggwi();
        }*/
    }

    void CreatePlayer()
    {
        GameObject playerTemp = PhotonNetwork.Instantiate("Player", Vector2.zero, Quaternion.identity, 0);
    }

    /*void SelectChanggwi()
    {
        Player[] players = PhotonNetwork.PlayerList;
        int randomIndex = Random.Range(0, players.Length);
        Player randomPlayer = players[randomIndex];
        randomPlayer.SetCustomProperties(new ExitGames.Client.Photon.Hashtable() { { "Role", "changgwi" } });

        foreach (Player player in players)
        {
            if (player != randomPlayer)
            {
                player.SetCustomProperties(new ExitGames.Client.Photon.Hashtable() { { "Role", "citizen" } });
            }
        }

        SendRoleToPlayers();
    }

    // 모든 플레이어에게 역할 정보를 전파하는 함수
    void SendRoleToPlayers()
    {
        Player[] players = PhotonNetwork.PlayerList;
        foreach (Player player in players)
        {
            SetPlayerRole(player);
        }
    }

    [PunRPC]
    void RPC_SetRole(int actorNumber, string role)
    {
        SetPlayerRole(player);
    }

    // 플레이어의 역할을 설정하는 메서드
    void SetPlayerRole(Player player)
    {
        string role = (string)player.CustomProperties["Role"];
        GameObject playerGameObject = PlayerControl.GetPlayerGameObject(player.ActorNumber);
        if (playerGameObject != null)
        {
            playerGameObject.GetComponent<PlayerControl>().SetRole(role);
        }
    }*/
}
