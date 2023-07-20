// 게임 시작 화면 감독 스크립트

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartDirector : MonoBehaviour
{
    private GameObject preference;

    // 설정 창 띄우기
    public void ClickPreferenceButton()
    {
        preference.SetActive(true);
    }

    // TODO: 게임 화면 이동 (게임 시작 버튼을 눌렀을 때)
    public void ClickStartButton()
    {
        Debug.Log("게임 화면으로 이동!");
        // SceneManager.LoadScene("게임화면");
    }

    // 게임 종료
    public void ClickExitButton()
    {
        #if UNITY_EDITOR    // 유니티 에디터에서도 게임 종료가 동작하도록 함
                UnityEditor.EditorApplication.isPlaying = false;
        #else               // 일반 경우
                Application.Quit();
        #endif
    }

    private void Start()
    {
        this.preference = GameObject.Find("Canvas").transform.Find("PreferenceBgPanel").gameObject;

        // 해상도 고정 - 처음에는 풀스크린(true)로 설정
        // TODO: 차후 파일 내의 설정 값을 받아와 설정하는 것으로 수정 필요
        Screen.SetResolution(1920, 1080, true);
    }
}