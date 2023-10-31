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
        SceneManager.LoadScene("Main");
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

        /** 설정 파일 생성 **/

        if (!PlayerPrefs.HasKey("backgroundVolume"))    // 배경음 볼륨
            PlayerPrefs.SetFloat("backgroundVolume", 100.0f);

        if (!PlayerPrefs.HasKey("soundEffectVolume"))   // 효과음 볼륨
            PlayerPrefs.SetFloat("soundEffectVolume", 100.0f);

        if (!PlayerPrefs.HasKey("language"))            // 언어
            PlayerPrefs.SetString("language", "Korean");

        if (!PlayerPrefs.HasKey("screenMode"))          // 화면 모드
            PlayerPrefs.SetString("screenMode", "full");
        
        
        /** 기존 값으로 게임 환경 세팅 **/

        // TODO: 배경음 볼륨 적용
        // TODO: 효과음 볼륨 적용
        // TODO: 언어 적용

        // 화면 모드 적용
        if (PlayerPrefs.GetString("screenMode") == "full")
        {
            Screen.SetResolution(1920, 1080, true);
        }
        else if (PlayerPrefs.GetString("screenMode") == "window")
        {
            Screen.SetResolution(1440, 810, false);
        }
    }
}