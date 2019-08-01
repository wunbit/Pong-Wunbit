using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameManager gameManager;
    //private Rigidbody2D rb2d;
    void FixedUpdate()
    {
        float v = Input.GetAxisRaw("Vertical");
        GetComponent<Rigidbody2D>().velocity = new Vector2(0, v * gameManager.PlayerSpeed);
    }
}
