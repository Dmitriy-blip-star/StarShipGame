using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

namespace Assets.Scripts.Bullet
{
    public class BulletMover : MonoBehaviour
    {
        float speed = 10;
        // Update is called once per frame
        void Update()
        {
            Vector3 position = transform.position;
            position = Vector3.Lerp(position, position + Vector3.up, speed * Time.deltaTime);
            transform.position = position;
            if (transform.position.y > 6)
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
}