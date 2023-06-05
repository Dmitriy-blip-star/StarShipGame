using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.ResourcesMenagerSystem
{
    public class EnemyLoader : MonoBehaviour
    {
        [Header("Settings")]
        [SerializeField] List<GameObject> loadedBackgrounds;

        [Tooltip("Enemy folder name in resources")]
        [SerializeField] string enemysFolderName;

        [Tooltip("Enemys name prefix")]
        [SerializeField] string enemyPrefix;

        [Tooltip("Enemy count in resources name")]
        [SerializeField] int enemysCount;
    }
}