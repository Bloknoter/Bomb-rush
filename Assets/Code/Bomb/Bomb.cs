using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace BombEngine
{
    public class Bomb : MonoBehaviour
    {
        [SerializeField]
        private Rigidbody2D myrigidbody;

        [SerializeField]
        private Transform mytransform;

        [SerializeField]
        private Health myhealth;

        [SerializeField]
        private GameObject ExplosionPrefab;

        [SerializeField]
        [Min(0)]
        private float ExplosionStrength;

        [SerializeField]
        [Min(0)]
        private float Radius;

        [SerializeField]
        [Min(0)]
        private float DamageRadius;

        [SerializeField]
        [Min(0)]
        private float ExplosionTiming;

        private bool isExploding;

        void Start()
        {
            myrigidbody.AddForce(mytransform.up * ExplosionStrength * 50);
            myhealth.OnValueChangedEvent += OnHealthChanged;
        }

        private bool wasTiming;
        void Update()
        {
            if (!wasTiming)
            {
                wasTiming = true;
                StartCoroutine(Timing());
            }
        }

        private IEnumerator Timing()
        {
            yield return new WaitForSeconds(ExplosionTiming);
            Explode();
        }

        private void Explode()
        {
            if (!isExploding)
            {
                isExploding = true;
            }
            else
            {
                return;
            }
            Collider2D[] colliders = Physics2D.OverlapCircleAll(mytransform.position, Radius);
            for (int i = 0; i < colliders.Length; i++)
            {
                if (colliders[i].gameObject != gameObject)
                {
                    Rigidbody2D thisrigidbody = colliders[i].gameObject.GetComponent<Rigidbody2D>();
                    if (thisrigidbody != null)
                    {
                        float distance = Vector2.Distance(mytransform.position, thisrigidbody.gameObject.transform.position);
                        thisrigidbody.AddForceAtPosition((thisrigidbody.gameObject.transform.position - mytransform.position) * ExplosionStrength / distance, thisrigidbody.centerOfMass, ForceMode2D.Force);
                        Health health = colliders[i].gameObject.GetComponent<Health>();
                        if (health != null)
                        {
                            if (distance < DamageRadius)
                                health.HealthValue--;
                        }
                    }
                }
            }
            GameObject explosion = Instantiate(ExplosionPrefab);
            explosion.transform.position = mytransform.position;
            Destroy(mytransform.gameObject);
        }

        private void OnHealthChanged(int previousvalue, int newvalue)
        {
            Explode();
        }
    }
}
