using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Player
{
    public class PlayerBattle : MonoBehaviour
    {
        public void Fight(int health, int damage) => health -= damage;
    }
}