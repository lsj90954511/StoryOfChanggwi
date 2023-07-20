// 설정 창 내의 기능 구현 스크립트

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PreferenceManager : MonoBehaviour
{
    private Button koreanBtn;       // 언어 설정-한국어 버튼
    private Button englishBtn;      // 언어 설정-영어 버튼

    public TMP_Text screenModeText;     // 화면 모드 설정 버튼 텍스트

    // 설정 창 닫기
    public void ClickCloseButton()
    {
        gameObject.SetActive(false);
    }

    // TODO: 배경음 조작 연동

    // TODO: 효과음 조작 연동

    // 언어-한국어 선택
    public void ClickKoreanButton()
    {
        koreanBtn.interactable = false;
        englishBtn.interactable = true;

        // TODO: 한국어로 전환
    }

    // 언어-영어 선택
    public void ClickEnglishButton()
    {
        englishBtn.interactable = false;
        koreanBtn.interactable = true;

        // TODO: 영어로 전환
    }

    // TODO: 화면 설정
    public void ClickScreenModeButton()
    {
        // TODO: if 조건식 수정 필요 - 파일의 설정 값을 토대로 판단하게끔
        if (screenModeText.text == "전체화면")
        {
            // 창 모드로 변환
            Screen.SetResolution(1440, 810, false);
            screenModeText.text = "창 모드";

            // TODO: 설정값 업데이트

        }
        else
        {
            // 전체화면으로 변환
            Screen.SetResolution(1920, 1080, true);
            screenModeText.text = "전체화면";

            // TODO: 설정값 업데이트

        }
    }

    private void Start()
    {
        this.koreanBtn = GameObject.Find("KoreanButton").GetComponent<Button>();
        this.englishBtn = GameObject.Find("EnglishButton").GetComponent<Button>();

        // TODO: 기존 설정값으로 세팅

    }
}
