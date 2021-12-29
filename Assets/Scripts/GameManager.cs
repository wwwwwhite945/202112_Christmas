using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public GameObject HowtoPlayScene; //HowtoPlay畫面
    public GameObject SettingScene; //Setting畫面
    public Image musicImg;
    public Sprite[] musicSpr;
    public AudioSource audioSource;
    public GameObject audioObj;
    static bool isAudioPlay = true;
    bool isMusic = true;

    void Start()
    {
        Screen.SetResolution(/*螢幕寬度*/1920,/*螢幕高度*/ 1080, /*是否全屏顯示*/true);

        if (isAudioPlay)
        {
            DontDestroyOnLoad(audioObj);
            isAudioPlay = false;
            audioSource.Play();
        }
    }

    void Update()
    {

    }

    public void GameStart() //開始遊戲
    {
        SceneManager.LoadScene("GameStart");
    }


    public void HowtoPlay() //打開HowtoPlay畫面
    {
        HowtoPlayScene.SetActive(true);
    }
    public void CloseHowtoPlay() //關閉HowtoPlay畫面
    {
        HowtoPlayScene.SetActive(false);
        ShowDebugLog("close how to play.");
    }

    public void Setting() //打開Setting畫面
    {
        SettingScene.SetActive(true);
    }
    public void CloseSetting() //關閉Setting畫面
    {
        SettingScene.SetActive(false);
    }

    public void MusicControl()
    {
        if (isMusic == true)
        {
            isMusic = false;
            musicImg.sprite = musicSpr[0];
            audioSource.Pause();
            ShowDebugLog("pause music now.");
        }
        else
        {
            isMusic = true;
            musicImg.sprite = musicSpr[1];
            audioSource.Play();
            ShowDebugLog("play music now.");
        }
    }

    void ShowDebugLog(string log)
    {
        Debug.Log(log);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
