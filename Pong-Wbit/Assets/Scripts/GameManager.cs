using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("Game Variables")]
    public float BallSpeed = 10f;
    public float ReboundAddSpeed = 0.05f;
    public float PlayerSpeed = 10f;
    public float EnemySpeed = 10f;
    
    [Header("Script References")]
    public Ball ball;
    public GameManager instance;

    void Awake()
    {
        ball = GameObject.Find("Ball").GetComponent<Ball>();
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }

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
