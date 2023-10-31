using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class PlayerControl : MonoBehaviour
{
    private PhotonView pv;

    private void Awake()
    {
        pv = GetComponent<PhotonView>();
    }
}
