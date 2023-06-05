using System.Collections;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.Pool;

namespace Assets.Scripts.Enemy
{
    [RequireComponent(typeof(PolygonCollider2D))]
    [RequireComponent(typeof(Rigidbody2D))]

    public class EnemyMover : MonoBehaviour
    {
        [Header("Settings")]
        [SerializeField] float curentSpeed;
        [SerializeField] float minSpeed = 3f;
        [SerializeField] float maxSpeed = 7f;

        [Tooltip("Boost moving speed per second")]
        [SerializeField] float boctySpeedPerSecond;

        [SerializeField] float nonBoostSpeedTime;

        [SerializeField] bool isPlay = true;


        private void Update()
        {
            if (isPlay)
            {
                curentSpeed = Random.Range(minSpeed, maxSpeed);
                Vector3 position = transform.position;
                position = Vector3.Lerp(position, position + Vector3.down, curentSpeed * Time.deltaTime);
                transform.position = position;
            }
        }

        IEnumerator SpeedCounter()
        {
            yield return new WaitForSeconds(nonBoostSpeedTime);

            while (true)
            {
                yield return new WaitForSeconds(0.1f);
                curentSpeed += boctySpeedPerSecond / 10;
                curentSpeed = Mathf.Clamp(curentSpeed, minSpeed, maxSpeed);
            }
        }

        public void OnGameStart()
        {
            StartCoroutine(SpeedCounter());
            isPlay = true;
        }

        public void OnPause() => isPlay = false;
        public void OnContinue() => isPlay = true;
    }

}