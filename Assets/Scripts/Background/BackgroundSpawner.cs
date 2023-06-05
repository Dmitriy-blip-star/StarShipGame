using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets.Scripts.Background
{
    [RequireComponent(typeof(BackgroundLoader))]
    public class BackgroundSpawner : MonoBehaviour
    {
        [Header("Components")]
        [SerializeField] BackgroundLoader backgroundLoader;

        [Header("Settings")]
        [SerializeField] Transform backgroundParentTransform;

        [Tooltip("Backgroudn on scene in one moment")]
        [SerializeField] int backgroundPoolSize;

        [Tooltip("Background size")]
        [SerializeField] Vector3 backgroundSize;

        [Tooltip("Background on scene")]
        [SerializeField] List<GameObject> spawnedBackgrounds;


        private void Awake()
        {
            if (backgroundLoader == null)
            {
                backgroundLoader = GetComponent<BackgroundLoader>();
            }
        }

        private void Update()
        {
            if (spawnedBackgrounds.Count < backgroundPoolSize)
            {
                SpawnBackgrounds();
            }
        }

        private void SpawnBackgrounds()
        {
            GameObject background = backgroundLoader.GetRandomBackground();
            GameObject spawnedBackground = Instantiate(background, backgroundParentTransform);

            GameObject lastSpawnedBackground = spawnedBackgrounds.Last();
            Vector3 lastSpawnedBackgroundPosition = lastSpawnedBackground.transform.localPosition;
            Vector3 backgroundPosition = lastSpawnedBackgroundPosition + backgroundSize;

            spawnedBackground.transform.localPosition = backgroundPosition;
            spawnedBackgrounds.Add(spawnedBackground);
        }

        public void DeleteBackground(GameObject background)
        {
            spawnedBackgrounds.Remove(background);
            Destroy(background);
        }
    }
}