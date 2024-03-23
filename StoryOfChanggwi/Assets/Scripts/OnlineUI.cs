using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OnlineUI : MonoBehaviour
{
    public void ClickBackBtn()
    {
        SceneManager.LoadScene("GameStart");
    }
}
