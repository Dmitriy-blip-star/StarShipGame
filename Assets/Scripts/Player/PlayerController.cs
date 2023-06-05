using Assets.Scripts.Menegers;
using UnityEngine;
using UnityEngine.Events;

namespace Assets.Scripts.Player
{

    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(PolygonCollider2D))]
    [RequireComponent(typeof(PlayerMovementController))]
    [RequireComponent(typeof(PlayerHealthController))]


    public class PlayerController : MonoBehaviour
    {
        [Header("Components")]
        [SerializeField] PlayerMovementController playerMovement;
        [SerializeField] PlayerHealthController playerHealth;

        [Header("Settings")]
        [SerializeField] float halfCameraWidth;
        [SerializeField] float halfCameraHeight;
        [SerializeField] Transform gun;
        //[SerializeField] int damagePower;
        public int damagePower { get; private set; }

        [SerializeField] UnityEvent move;
        [SerializeField] UnityEvent dead;
        [SerializeField] UnityEvent helthChanged;
        Vector2 moveVectorBull;

        private void Awake()
        {
            if (playerHealth == null) playerHealth = GetComponent<PlayerHealthController>();
            if (playerMovement == null) playerMovement = GetComponent<PlayerMovementController>();
        }

        public void OnMoveButtonDown()
        {
            playerMovement.Move();
        }

        void OnPlayerDead() => dead?.Invoke();

        private void Update()
        {
            //FiringLogic();
            CheckForBeingInCameraView();
        }
        //void FiringLogic()
        //{
        //    if (Input.GetKeyDown("space"))
        //    {
        //        moveVectorBull.y = transform.position.y + 0.7f;
        //        moveVectorBull.x = transform.position.x;
        //        Instantiate(bullet,moveVectorBull, Quaternion.identity);
        //    }
        //}

        void CheckForBeingInCameraView()
        {
            if (transform.position.x < -halfCameraWidth) transform.position = new Vector2(-halfCameraWidth, transform.position.y);
            if (transform.position.x > halfCameraWidth) transform.position = new Vector2(halfCameraWidth, transform.position.y);
            if (transform.position.y < -halfCameraHeight) transform.position = new Vector2(transform.position.x, -halfCameraHeight);
            if (transform.position.y > halfCameraHeight) transform.position = new Vector2(transform.position.x, halfCameraHeight);
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.tag == "Enemy")
            {
                Destroy(collision.gameObject);
            }
        }
    }
}