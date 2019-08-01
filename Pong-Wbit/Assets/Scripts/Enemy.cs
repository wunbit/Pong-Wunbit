﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameManager gameManager;
    public Ball ball;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector2 Aipos = GetComponent<Transform>().position;
        Vector2 Ballpos = ball.transform.position;
        if (Ballpos.y > Aipos.y/2)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, 1 * gameManager.EnemySpeed);
        }
        if (Ballpos.y < Aipos.y/2)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, -1 * gameManager.EnemySpeed);
        }
    }
}
