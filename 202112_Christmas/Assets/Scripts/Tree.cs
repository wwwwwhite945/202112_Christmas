using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tree : MonoBehaviour {


    Rigidbody2D rb;
    public float jump;  //物件跳躍高度
    bool isJumping;     //是否正在跳躍
    public GameControl gc; //引用"GameControl"腳本

    [Space(10)]
    [Header("物件圖片")]
    public Image treeImg;
    public Sprite[] treeSpr;

    void Start()
    {
        treeImg.sprite = treeSpr[0];
        rb = GetComponent<Rigidbody2D>();
        isJumping = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isJumping == false) //當按下空白鍵且非正在跳躍
        {
            rb.velocity = new Vector2(0, jump); //rigidbody的線速度，單位是每秒
            isJumping = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        isJumping = false;
        if (collision.gameObject.tag == "Gift")
        {
            treeImg.sprite = treeSpr[1];
            gc.GameOver(); //撞到即輸 //引用"GameControl"腳本中的"GameOver()"
        }
    }

}
