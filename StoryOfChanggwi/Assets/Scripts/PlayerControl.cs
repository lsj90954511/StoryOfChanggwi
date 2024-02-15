using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;

public class PlayerControl : MonoBehaviourPunCallbacks
{
    private PhotonView photonView;
    //public string role = "None";//역할 저장. 역할 : changgwi, citizen, ghost

    //플레이어 스프라이트
    public SpriteRenderer playerSpriteRenderer;
    [SerializeField]
    private Sprite[] sprites;

    private void Awake()
    {
        photonView = GetComponent<PhotonView>();
        playerSpriteRenderer = GetComponent<SpriteRenderer>();
    }
    void Start()
    {
        /*if(photonView.IsMine)
        {
            object roleObj;
            //PhotonNetwork.LocalPlayer.CustomProperties.TryGetValue("Role", out roleObj);
            //roleObj = (string)roleObj;
            //Debug.Log("Player role: " + role);
            
            if (PhotonNetwork.LocalPlayer.CustomProperties.TryGetValue("Role", out roleObj))
            {
                role = (string)roleObj;
                if (role == "changgwi")
                {
                    playerSpriteRenderer.sprite = sprites[5]; // 술래 스프라이트 설정
                }
                else
                {
                    int index = Random.Range(0, 5);
                    playerSpriteRenderer.sprite = sprites[index]; // 시민 스프라이트 설정
                }
            }
            else
            {
                Debug.LogWarning("Role not set for player!");
            }
        }*/
    }
    /*
    // 역할을 설정하는 메서드
    public void SetRole(string newRole)
    {
        role = newRole;
        Debug.Log("플레이어의 역할이 설정되었습니다: " + role);
        // 역할에 따른 동작을 수행할 수 있음
    }

    // Player 객체와 게임 오브젝트 간의 매핑을 추가합니다.
    public static void AddPlayerGameObjectMapping(Player player, GameObject gameObject)
    {
        if (!playerGameObjectMap.ContainsKey(player.ActorNumber))
        {
            playerGameObjectMap.Add(player.ActorNumber, gameObject);
        }
    }

    // ActorNumber에 해당하는 플레이어의 게임 오브젝트를 반환합니다.
    public static GameObject GetPlayerGameObject(int actorNumber)
    {
        if (playerGameObjectMap.ContainsKey(actorNumber))
        {
            return playerGameObjectMap[actorNumber];
        }
        else
        {
            Debug.LogError("No GameObject found for ActorNumber: " + actorNumber);
            return null;
        }
    }

    /*public void SetPlayerRole()
    {
        //창귀 플레이어 선정
        //모든 플레이어 리스트 가져오기
        Player[] players = PhotonNetwork.PlayerList;
        //랜덤 창귀 선택
        Player randomPlayer = players[Random.Range(0, players.Length)];
        //RPC로 창귀 역할 설정
        photonView.RPC("SetIsChanggwi", RpcTarget.AllBuffered, randomPlayer.ActorNumber);
        //나머지 플레이어는 주민으로 설정
        foreach (Player player in players)
        {
            if (player != randomPlayer)
            {
                photonView.RPC("SetIsChanggwi", RpcTarget.AllBuffered, player.ActorNumber);
            }
        }
    }

    [PunRPC]
    void SetIsChanggwi(int actorNumber)
    {
        Debug.Log("RPC SetIsChanggwi 호출됨. ActorNumber: " + actorNumber);
        Player player = PhotonNetwork.CurrentRoom.GetPlayer(actorNumber);
        //모든 플레이어의 스프라이트 설정
        int index = Random.Range(0, 5);
        Sprite select = sprites[index];
        playerSpriteRenderer.sprite = select;
        role = "citizen";

        // 만약 술래 역할이라면, 스프라이트 변경
        if (player != null && player == photonView.Owner)
        {
            playerSpriteRenderer.sprite = sprites[5];
            role = "changgwi";
        }
    }*/
}
