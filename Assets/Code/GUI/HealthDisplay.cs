using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace GUI
{
    public class HealthDisplay : MonoBehaviour
    {
        [SerializeField]
        private Health displayedHealth;

        [SerializeField]
        private GameObject[] Hearts;

        void Start()
        {
            displayedHealth.OnValueChangedEvent += OnValueChanged;
        }

        void Update()
        {

        }

        private void OnValueChanged(int previousvalue, int newvalue)
        {
            for (int i = 0; i < Hearts.Length; i++)
            {
                Hearts[i].SetActive(i < newvalue);
            }
        }
    }
}
