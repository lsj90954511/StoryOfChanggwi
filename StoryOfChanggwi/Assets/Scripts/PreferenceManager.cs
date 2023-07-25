// 설정 창 내의 기능 구현 스크립트

/**
 * 
 *  [PlayerPrefs 내 설정 키 값 이름]
 *  배경음 볼륨 값: backgroundVolume (Float)
 *  효과음 볼륨 값: soundEffectVolume (Float)
 *  언어 설정: language (String - Korean / English)
 *  화면 모드: screenMode (String - full / window)
 *  
 **/

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PreferenceManager : MonoBehaviour
{
    public Slider backgroundVolume;     // 배경음 볼륨
    public Slider soundEffecfVolume;    // 효과음 볼륨

    public Button koreanBtn;            // 언어 설정-한국어 버튼
    public Button englishBtn;           // 언어 설정-영어 버튼

    public TMP_Text screenModeText;     // 화면 모드 설정 버튼 텍스트

    // 설정 창 닫기
    public void ClickCloseButton()
    {
        gameObject.SetActive(false);
    }

    // 배경음 볼륨 조작
    public void ChangedBgVolumeSlider()
    {
        // 설정값 저장
        PlayerPrefs.SetFloat("backgroundVolume", backgroundVolume.value);

        // TODO: 볼륨 실제로 적용
    }

    // 효과음 볼륨 조작
    public void ChangedSFXVolumeSlider()
    {
        // 설정값 저장
        PlayerPrefs.SetFloat("soundEffectVolume", soundEffecfVolume.value);

        // TODO: 볼륨 실제로 적용
    }

    // 언어-한국어 선택
    public void ClickKoreanButton()
    {
        koreanBtn.interactable = false;
        englishBtn.interactable = true;

        // 설정값 저장
        PlayerPrefs.SetString("language", "Korean");

        // TODO: 한국어 적용
    }

    // 언어-영어 선택
    public void ClickEnglishButton()
    {
        englishBtn.interactable = false;
        koreanBtn.interactable = true;

        // 설정값 저장
        PlayerPrefs.SetString("language", "English");

        // TODO: 영어 적용
    }

    // TODO: 화면 설정
    public void ClickScreenModeButton()
    {
        if (screenModeText.text == "전체화면")
        {
            // 창 모드로 변환
            Screen.SetResolution(1440, 810, false);
            screenModeText.text = "창 모드";

            // 설정값 저장
            PlayerPrefs.SetString("screenMode", "window");
        }
        else
        {
            // 전체화면으로 변환
            Screen.SetResolution(1920, 1080, true);
            screenModeText.text = "전체화면";

            // 설정값 저장
            PlayerPrefs.SetString("screenMode", "full");
        }
    }

    private void Start()
    {
        /** 기존 설정값으로 UI 세팅 **/

        backgroundVolume.value = PlayerPrefs.GetFloat("backgroundVolume");
        soundEffecfVolume.value = PlayerPrefs.GetFloat("soundEffectVolume");
        
        if (PlayerPrefs.GetString("language") == "Korean")
        {
            koreanBtn.interactable = false;
            englishBtn.interactable = true;
        }
        else if (PlayerPrefs.GetString("language") == "English")
        {
            englishBtn.interactable = false;
            koreanBtn.interactable = true;
        }

        if (PlayerPrefs.GetString("screenMode") == "full")
        {
            screenModeText.text = "전체화면";
        }
        else if (PlayerPrefs.GetString("screenMode") == "window")
        {
            screenModeText.text = "창 모드";
        }
    }
}
