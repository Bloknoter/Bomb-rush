using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace BombEngine
{
    public class Explosion : MonoBehaviour
    {
        [SerializeField]
        private AudioSource audioSource;

        public void Destroy()
        {
            Destroy(transform.gameObject);
        }
    }
}
