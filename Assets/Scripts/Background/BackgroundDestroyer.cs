using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Background
{
    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(BoxCollider2D))]

    public class BackgroundDestroyer : MonoBehaviour
    {
        [Header("Components")]
        [SerializeField] BackgroundSpawner backgroundSpawner;
        [SerializeField] EnemySpawner enemySpawner;


        private void Awake()
        {
            if (backgroundSpawner == null) backgroundSpawner = GetComponent<BackgroundSpawner>();
            if(enemySpawner == null) enemySpawner = GetComponent<EnemySpawner>();
        }

        private void OnTriggerEnter2D (Collider2D collision)
        {
            switch (collision.gameObject.tag)
            {
                case "Background":
                    backgroundSpawner.DeleteBackground(collision.transform.parent.gameObject);
                    break;
                case "Enemy":
                    enemySpawner.DeleteEnemy(collision.gameObject);
                    break;
            }
        }


    }
}