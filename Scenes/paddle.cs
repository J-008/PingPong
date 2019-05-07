using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class paddle : MonoBehaviour
{
    float speed;
    float height;
    string input;
   public bool isRight;
    // Start is called before the first frame update
    void Start()
    {
        height = transform.localScale.y;
        speed = 7f;
    }
    public void SetSide(bool value)
    {
        Vector2 pos = Vector2.zero;

        if(value==true)
        {//prawa
            isRight = value;
            pos = new Vector2(GameManager.topRight.x, 0);
            pos -= Vector2.right * transform.localScale.x;
            input = "paddleright";
        }
        else
        {//lewa
            pos = new Vector2(GameManager.bottomLeft.x, 0);
            pos += Vector2.right * transform.localScale.x;
            input = "paddleleft";
        }
        transform.position = pos;
        transform.name = input;
    }
    // Update is called once per frame
    void Update()
    {
        float move = Input.GetAxis(input) * Time.deltaTime * speed;

        if (transform.position.y < GameManager.bottomLeft.y + height / 2 && move < 0)
            move = 0;
        if (transform.position.y > GameManager.topRight.y - height / 2 && move > 0)
            move = 0;

            transform.Translate(move * Vector2.up);
    }
}
