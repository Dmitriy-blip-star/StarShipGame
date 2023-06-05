using System.Collections;
using UnityEngine;
using UnityEngine.Events;

namespace Assets.Scripts.Menegers
{
    public class PlayerHealthController : MonoBehaviour
    {
        [Header("Settings")]
        [SerializeField] int health = 3;
        [Space]
        [SerializeField] UnityEvent<int> healthChanged;
        [SerializeField] UnityEvent playerDead;

        void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.tag == "Enemy")
            {
                if (health > 0)
                {
                    health--;
                    healthChanged?.Invoke(health);
                }
                else playerDead?.Invoke();
            }
        }
    }   
}
