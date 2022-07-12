using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace BonusEngine
{
    public class HealthBonus : MonoBehaviour
    {
        [SerializeField]
        private Animator myanimator;

        [SerializeField]
        private Rigidbody2D myrigidbody;

        [SerializeField]
        private int addinghealth;

        public int AddingHealth
        {
            get
            {
                return addinghealth;
            }
        }

        public void Collect()
        {
            myrigidbody.bodyType = RigidbodyType2D.Static;
            GetComponent<Collider2D>().isTrigger = true;
            myanimator.SetInteger("state", 1);
        }

        private void Destroy()
        {
            Destroy(transform.gameObject);
        }
    }
}
