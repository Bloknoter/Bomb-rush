using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using BonusEngine;

namespace Player
{
    public class HealthCollector : MonoBehaviour
    {
        [SerializeField]
        private Health health;

        void Start()
        {

        }

        void Update()
        {

        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            HealthBonus healthbonus = collision.gameObject.GetComponent<HealthBonus>();
            if (healthbonus != null)
            {
                health.HealthValue += healthbonus.AddingHealth;
                healthbonus.Collect();
            }
        }
    }
}
