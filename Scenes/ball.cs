using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ball : MonoBehaviour
{
    Text text;
    int counterP=0, counterL=0;    
    float speed=5f;
    float radius;
    int scoreLimit=5;
    Vector2 direction;
    OptionsScript close;
    // Start is called before the first frame update
    void Start()
    {
        float number2 = UnityEngine.Random.Range(-1.0f, 1.0f);
        float number = UnityEngine.Random.Range(-1.0f, 1.0f);
        Vector2 rand = new Vector2(number,number2);
        //direction = Vector2.one.normalized;
        direction = rand;
        radius = transform.localScale.x / 2;
        close = new OptionsScript();
    }

    // Update is called once per frame
    void Update()
    {
       if (Input.GetKeyDown(KeyCode.Escape))
         close.OpenNewScene("Menu");

        transform.Translate(direction * speed * Time.deltaTime);

        if(speed<7.5f)
        speed +=0.01f;

        if (transform.position.y < GameManager.bottomLeft.y + radius / 2 && direction.y < 0)
            direction.y = -direction.y;
        if (transform.position.y > GameManager.topRight.y - radius / 2 && direction.y > 0)
            direction.y = -direction.y;

        if (transform.position.x < GameManager.bottomLeft.x + radius / 2 && direction.x < 0)
        {
            counterP++;

           System.Random random = new System.Random();
            float number = UnityEngine.Random.Range(-1.0f, 1.0f);
           // Debug.Log("rADIUS p: " + number);

            Vector2 z = new Vector2(1, number);
            radius = transform.localScale.x / 2;
            direction = z;
        }
        
        if (transform.position.x > GameManager.topRight.x - radius / 2 && direction.x > 0)
        {
            counterL++;
           
             System.Random random =new System.Random();
            float number = UnityEngine.Random.Range(-1.0f, 1.0f);
            //Debug.Log("rADIUS: "+ number);

            Vector2 z = new Vector2(-1, number);
            radius = transform.localScale.x / 2;
            direction = z;

        }
        if(scoreLimit==counterL || scoreLimit == counterP)
        {
            if (counterL > counterP)
            {
                Debug.Log("Wygrał gracz lewy");
            }
            else
            {
                Debug.Log("Wygrał gracz prawy");
            }
            SceneManager.LoadScene("Menu");
        }
        
    }

    public Text GetText()
    {
        return text;
    }
    public int GetCounterP()
    {
        return counterP;
    }
    public int GetCounterL()
    {
        return counterL;
    }
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag=="paddle")
        {
            bool isRight = other.GetComponent<paddle>().isRight;

            if (isRight == true && direction.x > 0)
                direction.x = -direction.x;
            if (isRight == false && direction.x < 0)
                direction.x = -direction.x;
        }
    }
}
