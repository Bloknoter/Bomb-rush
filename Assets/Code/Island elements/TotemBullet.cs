using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Game.Island
{
    public class TotemBullet : MonoBehaviour
    {
        [SerializeField]
        private Transform mytransform;

        [SerializeField]
        private Rigidbody2D myrigidbody;

        [SerializeField]
        private float speed = 1f;

        void Start()
        {

        }

        void Update()
        {

        }

        private void FixedUpdate()
        {
            myrigidbody.MovePosition((Vector2)mytransform.position + new Vector2(speed * Time.deltaTime, 0));
            if(mytransform.position.x >= 10)
            {
                Destroy(gameObject);
            }
        }

        private void OnCollisionEnter2D(Collision2D collision)
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
