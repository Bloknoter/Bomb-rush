using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace TimerEngine
{
    public class Timer : MonoBehaviour
    {
        [SerializeField]
        private Text timeT;

        private int time;

        public int TimeCount
        {
            get
            {
                return time;
            }
        }

        private bool isGoing = true;

        void Start()
        {
            timeT.text = "0:00";
        }

        private bool wasCounting;

        void Update()
        {
            if (!wasCounting && isGoing)
            {
                wasCounting = true;
                StartCoroutine(Count());
            }
        }

        public void Stop()
        {
            isGoing = false;   
        }

        private IEnumerator Count()
        {
            yield return new WaitForSecondsRealtime(1f);
            if (isGoing)
            {
                time++;
                DisplayTime();
                wasCounting = false;
            } 
        }

        private void DisplayTime()
        {
            timeT.text = GUI.ScoreDisplay.DeserializeInt(time);
        }

    }
}
