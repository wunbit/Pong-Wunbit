using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public float BallSpeed = 30f;
    public float PlayerSpeed = 10f;
    public float EnemySpeed = 10f;
    public Ball ball;

    // Start is called before the first frame update
    void Start()
    {
        ball.BallStart();
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
