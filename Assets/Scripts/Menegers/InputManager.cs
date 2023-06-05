using System.Collections;
using UnityEngine;
using UnityEngine.Events;

namespace Assets.Scripts.Menegers
{
    public class InputManager : MonoBehaviour
    {
        [Header("Settings")]
        [SerializeField] bool isGameStarted;
        [SerializeField] bool isPlayerDead;


        [SerializeField] UnityEvent gameStart;
        [SerializeField] UnityEvent restartLevel;
        [SerializeField] UnityEvent moveButtonDown;

        public void OnPlayerDead() => isPlayerDead = true;

        public void onRestartButtonDown()
        {
            if (isPlayerDead)
            {
                restartLevel?.Invoke();
            }
        }

        private void Update()
        {
            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.W)||
                Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
            {
                OnMoveButtonDown();
            }
        }

        void OnPlayButtonDown()
        {
            if (isGameStarted == false)
            {
                isGameStarted= true;
                gameStart?.Invoke();
            }
        }

        public void OnMoveButtonDown()
        {
            moveButtonDown?.Invoke();
        }
    }
}