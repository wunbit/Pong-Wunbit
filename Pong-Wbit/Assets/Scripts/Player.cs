using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameManager gameManager;
    private float speed;
    //private Rigidbody2D rb2d;
    void Start()
    {
        speed = gameManager.PlayerSpeed;
    }

    public void ResetPosition()
    {
        GetComponent<Rigidbody2D>().position = new Vector2(-6.75f,0);
    }
    void FixedUpdate()
    {
        if (!gameManager.gameOver)
        {
            float v = Input.GetAxisRaw("Vertical");
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, v * speed);
        }
    }
}
