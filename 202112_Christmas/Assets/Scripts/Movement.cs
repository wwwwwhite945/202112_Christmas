using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    public float movementSpeed; //移動速度
    public float startPosition; //開始位置
    public float endPosition; //結束位置

    private void Start()
    {

    }
    void Update()
    {
        transform.position = new Vector2(transform.position.x - movementSpeed * Time.deltaTime * 2, transform.position.y); //物件移動根據移動速度、兩幀之間的間隔時間及自定義變數
        if (transform.position.x <= endPosition) //如果物件目前位置x小於結束位置
        {
            if (gameObject.tag == "Gift")
            {
                Destroy(gameObject); //避免生成過多gift
            }
            else
            {
                transform.position = new Vector2(startPosition, transform.position.y); //將物件改至起始位置
            }
        }
    }
}
