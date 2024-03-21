using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviourPunCallbacks
{
    public static GameManager instance = null;

    public PhotonView pv;
    public ParticleSystem deathEffect;
    Wander wander;

    float timer;
    bool dead = false;

    private int deadPlayer = 0;

    [SerializeField]
    private GameObject leaveBtn;
    [SerializeField]
    private GameObject leavePanel;
    [SerializeField]
    private TMP_Text result;

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
        wander = GameObject.Find("Changgwi").GetComponent<Wander>();
    }

    void Start()
    {
        pv = GetComponent<PhotonView>();
        if (PhotonNetwork.IsMasterClient)
            CreatePlayer();
        timer = 0.0f;
    }

    void Update()
    {
        //패널 보여줌
        if (PhotonNetwork.CurrentRoom.PlayerCount == deadPlayer)
        {
            ShowLosePanel();
        }

        if (wander.getHp() <= 0)
        {
            ShowWinPanel();
        }
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
        Vector3 hitPoint = player.transform.position;
        Destroy(Instantiate(deathEffect.gameObject, hitPoint, Quaternion.FromToRotation(Vector3.forward, hitPoint)), deathEffect.main.startLifetimeMultiplier);
        player.SetActive(false);
        deadPlayer++;
    }

    public void ShowLosePanel()
    {
        //패널 보여주기
        result.text = "패배";
        leavePanel.SetActive(true);
    }
    public void ShowWinPanel()
    {
        //패널 보여주기
        result.text = "승리";
        leavePanel.SetActive(true);
    }

    public void EndGame()
    {
        leavePanel.SetActive(false);
        PhotonNetwork.LeaveRoom();
    }

    public override void OnLeftRoom()
    {
        SceneManager.LoadScene("Main");
    }
}
