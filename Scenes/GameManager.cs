using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
    public ball ball;
    public paddle paddle;
    public Text Text;

    public static Vector2 bottomLeft;
    public static Vector2 topRight;

    public static float startX;
    public static float startY;
    // Start is called before the first frame update
    void Start()
    {
        bottomLeft = Camera.main.ScreenToWorldPoint(new Vector2(0, 0));
        topRight = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
        
       ball = Instantiate(ball) as ball;
       startX= ball.transform.localScale.x;
        startY = ball.transform.localScale.y;
        paddle paddle1 = Instantiate(paddle) as paddle;
        paddle paddle2 = Instantiate(paddle) as paddle;

        paddle1.SetSide(true);
        paddle2.SetSide(false);
    }

    // Update is called once per frame
    void Update()
    {
        int cp = ball.GetCounterP();
        int lp = ball.GetCounterL();
        UpdateText(cp, lp);

    }
    void UpdateText(int cp, int lp)
    {
        Text.text = "WYNIK " + lp.ToString() + ":" + cp.ToString();
    }
}
