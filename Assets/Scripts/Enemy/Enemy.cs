using Assets.Scripts.Player;
using UnityEngine;

namespace Assets.Scripts.Enemy
{
    [RequireComponent(typeof(EnemyBattle))]
    [RequireComponent(typeof(EnemyMover))]
    
    public class Enemy : MonoBehaviour
    {
        [Header("Components")]
        [SerializeField] EnemyBattle enemyBattle;
        [SerializeField] EnemyMover enemyMover;
        [SerializeField] EnemySpawner enemySpawner;
        [SerializeField] PlayerController player;

        [Header("Settings")]
        [SerializeField] int health;
        [SerializeField] int damagePower;

        private void Awake()
        {
            if(enemyBattle == null) enemyBattle = GetComponent<EnemyBattle>();
            if(enemyMover == null) enemyMover= GetComponent<EnemyMover>();
        }
    }
}