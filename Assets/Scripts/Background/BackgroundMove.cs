using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

namespace Assets.Scripts.Background
{
    public class BackgroundMove : MonoBehaviour
    {
        [Header("Settings")]
        [Tooltip("Minimum moving speed")]
        [SerializeField] float minSpeed;

        [Tooltip("Maximum moving speed")]
        [SerializeField] float maxSpeed;

        [Tooltip("Curent speed")]
        [SerializeField] float speed;

        [Tooltip("Boost moving speed per second")]
        [SerializeField] float boctySpeedPerSecond;

        [SerializeField] float nonBoostSpeedTime;

        [SerializeField] bool isPlay;

        private void Update()
        {
            if (isPlay)
            {
                Vector3 position = transform.position;
                position = Vector3.Lerp(position, position + Vector3.down, speed * Time.deltaTime);
                transform.position = position;
            }
        }

        IEnumerator SpeedCounter()
        {
            yield return new WaitForSeconds(nonBoostSpeedTime);

            while (true)
            {
                yield return new WaitForSeconds(0.1f);
                speed += boctySpeedPerSecond / 10;
                speed = Mathf.Clamp(speed, minSpeed, maxSpeed);
            }
        }

        public void OnGameStart()
        {
            StartCoroutine(SpeedCounter());
            isPlay= true;
        }

        public void OnPause() => isPlay= false;

        public void OnContinue()=> isPlay= true;

    }
}