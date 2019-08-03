using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public GameManager gameManager;
    private Rigidbody2D rb2d;
    private float speed;
    private float initialspeed;
    private float reboundSpeed;
    private bool playerscored;


    // Start is called before the first frame update
    void Awake()
    {
        reboundSpeed = gameManager.ReboundAddSpeed;
        initialspeed = gameManager.BallSpeed;
        playerscored = true;
        rb2d = GetComponent<Rigidbody2D>();
    }

    public void StopBall()
    {
        rb2d.velocity = Vector2.zero;
        rb2d.transform.position = Vector2.zero;
    }

    public void BallStart()
    {
        speed = initialspeed;
        if (playerscored)
        {
            rb2d.velocity = Vector2.right * speed;
            playerscored = false;
            return;
        }
        if (!playerscored)
        {
            rb2d.velocity = Vector2.left * speed;
            playerscored = false;
            return;
        }
    }

    float hitFactor(Vector2 ballPos, Vector2 racketPos, float racketHeight)
    {
        float pos = (ballPos.y - racketPos.y) / racketHeight;
        return (ballPos.y - racketPos.y) / racketHeight;
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        speed += reboundSpeed;
        if (col.gameObject.tag == "Paddle")
        {
            float y = hitFactor(transform.position, col.transform.position, col.collider.bounds.size.y);
            if (col.transform.position.x > 0)
            {
                Vector2 dir = new Vector2(-1, y).normalized;
                rb2d.velocity = dir * speed;
            }
            if (col.transform.position.x < 0)
            {
                Vector2 dir = new Vector2(1, y).normalized;
                rb2d.velocity = dir * speed;
            }
        }
        if (col.gameObject.tag == "ScoreLeft")
        {
            rb2d.velocity = Vector2.zero;
            rb2d.transform.position = Vector2.zero;
            gameManager.EnemyScore();
            Invoke("BallStart", 2);
        }
        if (col.gameObject.tag == "ScoreRight")
        {
            rb2d.velocity = Vector2.zero;
            rb2d.transform.position = Vector2.zero;
            playerscored = true;
            gameManager.PlayerScore();
            Invoke("BallStart", 2);
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
