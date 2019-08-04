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
    void Update()
    {
        Vector2 Aipos = GetComponent<Transform>().position;
        Vector2 Ballpos = ball.transform.position;
        if (!gameManager.gameOver)
        {
            if (Ballpos.y > Aipos.y+1.5)
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2(0, speed);
                //Debug.Log("moving Up");
                //transform.position += new Vector3 (0, speed * Time.deltaTime, 0); //this is too slow and choppy, though it does stop w
            }
            if (Ballpos.y < Aipos.y-1.5)
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2(0, -speed);
                //Debug.Log("moving Down");
                //transform.position += new Vector3 (0, -speed * Time.deltaTime, 0);
            }
            if (Ballpos.y <= Aipos.y+0.05 && Ballpos.y >= Aipos.y-0.05)
            {
                GetComponent<Rigidbody2D>().velocity = Vector2.zero;
                //Debug.Log("Not Moving");
            }
        }
    }
}
