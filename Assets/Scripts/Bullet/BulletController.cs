using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    [SerializeField] GameObject bullet;
    float speed = 10;
    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(bullet, transform.position, Quaternion.identity);
        }
        //_BulletMovement();
    }

    private void _BulletMovement()
    {
        Vector3 position = transform.position;
        position = Vector3.Lerp(position, position + Vector3.down, speed * Time.deltaTime);
        bullet.transform.position = position;
        if (bullet.transform.position.y > 6)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            Destroy(gameObject);
            Destroy(collision.gameObject);
        }
    }
}
