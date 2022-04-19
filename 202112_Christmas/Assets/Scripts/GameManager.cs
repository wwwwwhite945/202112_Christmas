using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [Header("設定&遊玩方法畫面")]
    public GameObject HowtoPlayScene; //HowtoPlay畫面
    public GameObject SettingScene; //Setting畫面

    [Space(10)]
    [Header("音樂控制")]
    public Image musicImg;      //音樂開關
    public Sprite[] musicSpr;   //開&關圖片
    public AudioSource audioSource;
    public GameObject audioObj;
    static bool isAudioPlay = true; //確認目前是否有正在播放的AudioSource，true表示目前"有"播放中的AudioSource
    bool isMusic = true;            //確認目前是否正在播放中

    void Start()
    {
        Screen.SetResolution(/*螢幕寬度*/1920,/*螢幕高度*/ 1080, /*是否全屏顯示*/true); //控制畫面大小及比例

        if (isAudioPlay)
        {
            DontDestroyOnLoad(audioObj);    //遊戲中不刪除
            isAudioPlay = false;            //避免第二次進入場景時與DontDestroy衝突
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
    }

    public void Setting() //打開Setting畫面
    {
        SettingScene.SetActive(true);
    }
    public void CloseSetting() //關閉Setting畫面
    {
        SettingScene.SetActive(false);
    }

    public void MusicControl() //音樂控制
    {
        if (isMusic == true)
        {
            isMusic = false;
            musicImg.sprite = musicSpr[0];
            audioSource.Pause();
            Debug.Log("pause music now.");
        }
        else
        {
            isMusic = true;
            musicImg.sprite = musicSpr[1];
            audioSource.Play();
            Debug.Log("play music now.");
        }
    }

    public void QuitGame() //結束遊戲
    {
        Application.Quit();
    }
}
