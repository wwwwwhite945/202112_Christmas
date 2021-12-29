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
        transform.position = new Vector2(transform.position.x - movementSpeed * Time.deltaTime * 2, transform.position.y);
        if (transform.position.x <= endPosition)
        {
            if (gameObject.tag == "Gift")
            {
                Destroy(gameObject); //避免生成過多gift
            }
            else
            {
                transform.position = new Vector2(startPosition, transform.position.y);
            }
        }
    }
}
