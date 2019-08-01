using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void BallStart()
    {
        GetComponent<Rigidbody2D>().velocity = Vector2.right * gameManager.BallSpeed;
    }

    float hitFactor(Vector2 ballPos, Vector2 racketPos, float racketHeight)
    {
        //float pos = (ballPos.y - racketPos.y) / racketHeight;
        //Debug.Log(pos);
        return (ballPos.y - racketPos.y) / racketHeight;
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        gameManager.BallSpeed += 0.1f;
        if (col.gameObject.tag == "Paddle")
        {
            float y = hitFactor(transform.position, col.transform.position, col.collider.bounds.size.y);
            if (col.transform.position.x > 0)
            {
                Vector2 dir = new Vector2(-1, y).normalized;
                GetComponent<Rigidbody2D>().velocity = dir * gameManager.BallSpeed;
            }
            if (col.transform.position.x < 0)
            {
                Vector2 dir = new Vector2(1, y).normalized;
                GetComponent<Rigidbody2D>().velocity = dir * gameManager.BallSpeed;
            }
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
