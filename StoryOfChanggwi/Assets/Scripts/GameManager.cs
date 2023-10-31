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
    }

    void CreatePlayer()
    {
        GameObject playerTemp = PhotonNetwork.Instantiate("Player", Vector2.zero, Quaternion.identity, 0);
    }
}
