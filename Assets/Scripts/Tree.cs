using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tree : MonoBehaviour {


    Rigidbody2D rb;
    public float jump;
    bool isJumping;
    public GameControl gc;
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
        if (Input.GetKeyDown(KeyCode.Space) && isJumping == false)
        {
            rb.velocity = new Vector2(0, jump);
            isJumping = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        isJumping = false;
        if (collision.gameObject.tag == "Gift")
        {
            treeImg.sprite = treeSpr[1];
            gc.GameOver(); //撞到即輸
        }
    }

}
