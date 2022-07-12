using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Game.Catacombs
{
    public class Stalactite : MonoBehaviour
    {
        [SerializeField]
        private Transform mytransform;

        [SerializeField]
        private Rigidbody2D myrigidbody;

        private bool isMoving = false;

        public bool IsMoving
        {
            get { return isMoving; }
            set
            {
                if (value == true)
                    isMoving = value;
                myrigidbody.bodyType = RigidbodyType2D.Dynamic;
            }
        }

        void Start()
        {
            myrigidbody.bodyType = RigidbodyType2D.Kinematic;
        }

        void Update()
        {
            
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (isMoving)
            {
                if (collision.gameObject.layer != 12)
                {
                    Health health = collision.gameObject.GetComponent<Health>();
                    if (health != null)
                    {
                        health.HealthValue -= 1;
                    }
                    Destroy(gameObject);
                }
            }
        }
    }
}
