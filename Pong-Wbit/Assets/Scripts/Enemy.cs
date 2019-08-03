using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameManager gameManager;
    public Ball ball;
    private float speed;
    // Start is called before the first frame update
    void Start()
    {
        speed = gameManager.EnemySpeed;
    }

    public void ResetPosition()
    {
        GetComponent<Rigidbody2D>().position = new Vector2(6.75f,0);
        GetComponent<Rigidbody2D>().velocity = Vector2.zero;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector2 Aipos = GetComponent<Transform>().position;
        Vector2 Ballpos = ball.transform.position;
        //float aiposy = Aipos.y;
        //float ballposy = Ballpos.y;
        if (!gameManager.gameOver)
        {
            if (Ballpos.y > Aipos.y+1.5)
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2(0, 1 * speed);
            }
            if (Ballpos.y < Aipos.y-1.5)
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2(0, -1 * speed);
            }
        }
        
    }
}
