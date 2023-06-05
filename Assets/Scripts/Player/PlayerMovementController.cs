using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Player
{
    public class PlayerMovementController : MonoBehaviour
    {
        [Header("Components")]
        [SerializeField] Rigidbody2D rb;
        Vector2 moveVector;

        [Header("Settings")]
        [SerializeField] float speed;

        private void Awake()
        {
            if (rb == null) rb = GetComponent<Rigidbody2D>();
        }

        public void Move()
        {
            float horizontalMovement = Input.GetAxis("Horizontal");
            float verticalMovement = Input.GetAxis("Vertical");
            Vector2 direct = new Vector2(horizontalMovement, verticalMovement);
            transform.Translate(direct * -speed * Time.deltaTime);
        }
    }

}