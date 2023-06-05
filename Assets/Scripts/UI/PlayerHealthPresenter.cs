using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Player
{
    [RequireComponent(typeof(Text))]

    public class PlayerHealthPresenter: MonoBehaviour
    {
        [Header("Components")]
        [SerializeField] Text hpText;

        private void Awake()
        {
            if (hpText == null) hpText.GetComponent<Text>();
        }

        public void OnHpChanged(int health) => hpText.text =  $"Health {health}";
    }
}