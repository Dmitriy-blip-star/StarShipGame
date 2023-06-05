using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BossScript : MonoBehaviour
{
    public float speed = 5;
    static int bossHealth = 3;

    bool wall = false;

    void Start()
    {
        
    }

    
    void FixedUpdate()
    {
        MovementBoss();
    }

    private void MovementBoss()
    {
        if (wall)
        {
            transform.position = new Vector2(transform.position.x - speed, transform.position.y);
        }
        else
            transform.position = new Vector2(transform.position.x + speed, transform.position.y);        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "WallR")
        {
            wall = true;
        }
        else if (collision.tag == "WallL")
        {
            wall = false;
        }

        if (collision.tag == "Bullet")
        {
            if (bossHealth > 1)
            {
                Destroy(collision.gameObject);
                bossHealth--;
            }
            else
            {
                Destroy(gameObject);
                Destroy(collision.gameObject);
            }

        }
    }
}
