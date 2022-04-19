using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameControl : MonoBehaviour
{
    [Header("Gift控制")]
    public GameObject gift;
    public GameObject giftSpawnPosition; //gift生成位置
    public float spawnTime; //gift生成速度

    [Space(10)]
    [Header("其他")]
    float timer;
    public GameObject GameOverScene;    //GameOver畫面
    public Text scoreText;
    double score;                       //分數
    public Text finalScoreText;

    // Use this for initialization
    void Start()
    {
        Time.timeScale = 10; //時間速度為10
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        score += 0.01;
        if (timer >= spawnTime)
        {
            Instantiate(gift, giftSpawnPosition.transform); //生成Gift
            timer = 0;
        }
        if (score >= 50)
        {
            spawnTime = UnityEngine.Random.Range(10, 20);
        }
        int scoreTemp = (int)score;
        scoreText.text = "SCORE：" + scoreTemp;
    }

    public void GoToLobby() //回到遊戲大廳
    {
        SceneManager.LoadScene("GameLobby");
    }

    public void GameOver()
    {
        Time.timeScale = 0; //時間速度為0(會停止運作)
        GameOverScene.SetActive(true);
        int scoreTemp = (int)score;
        finalScoreText.text = "SCORE：" + scoreTemp;
    }
}
