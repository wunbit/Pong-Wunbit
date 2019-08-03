using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [Header("Game Variables")]
    public float BallSpeed = 10f;
    public float ReboundAddSpeed = 0.05f;
    public float PlayerSpeed = 10f;
    public float EnemySpeed = 10f;
    public int endScore = 2;

    private int enemyScore;
    private int playerScore;
    public bool gameOver;
    
    [Header("Script References")]
    public Text playertext;
    public Text enemytext;
    public Text endText;
    public Ball ball;
    public GameManager instance;

    public Player Player;
    public Enemy Enemy;

    void Awake()
    {
        endText.text = "";
        gameOver = false;
        enemyScore = 0;
        playerScore = 0;
        ball = GameObject.Find("Ball").GetComponent<Ball>();  //where are now getting the instance where the ball script is, if not then nullreference error happens
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

    public void PlayerScore()
    {
        playerScore++;
        playertext.text = playerScore.ToString();
    }

    public void EnemyScore()
    {
        enemyScore++;
        enemytext.text =  enemyScore.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerScore == endScore)
        {
            gameOver = true;
            ball.StopBall();
            Player.ResetPosition();
            Enemy.ResetPosition();
            //Debug.Log("You win");
            endText.text = "You WIN";
        }
        if (enemyScore == endScore)
        {
            gameOver = true;
            ball.StopBall();
            Player.ResetPosition();
            Enemy.ResetPosition();
            //Debug.Log("You lose");
            endText.text = "You LOSE";
        }
    }
}
