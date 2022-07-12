using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Player.DialogSystem
{
    public class Dialog : MonoBehaviour
    {
        [SerializeField]
        private Animator myanimator;

        [SerializeField]
        [Min(0)]
        private float ShowTime;

        void Start()
        {
            gameObject.SetActive(false);
        }

        void Update()
        {

        }

        public void Open()
        {
            StopAllCoroutines();
            gameObject.SetActive(true);
            myanimator.SetTrigger("open");
            StartCoroutine(Show());
        }

        private IEnumerator Show()
        {
            yield return new WaitForSeconds(ShowTime);
            myanimator.SetTrigger("close");
        }

        public void Close()
        {
            gameObject.SetActive(false);
        }
    }
}
