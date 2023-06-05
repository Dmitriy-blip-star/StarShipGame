using Assets.Scripts.Player;
using JetBrains.Annotations;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Enemy
{
    public class EnemyBattle : MonoBehaviour
    {
        public void Attack(int health, int damage) => health -= damage;
        public void TakeDamage(int health, int damage) => health -= damage;
    }
}