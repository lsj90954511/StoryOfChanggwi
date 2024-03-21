using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    Vector3 cameraPosition = new Vector3(0, 0, -10);
    [SerializeField]
    public Transform target;

    /*void FixedUpdate()
    {
        transform.position = target.position + cameraPosition;
    }*/
}
