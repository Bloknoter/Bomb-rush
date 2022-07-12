using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace GUI
{
    public class FinishResultsDisplay : MonoBehaviour
    {
        [SerializeField]
        private Text PreviusScoreT;

        [SerializeField]
        private Text LastScoreT;

        private int previousscore;

        void Start()
        {

        }

        void Update()
        {

        }

        public void DisplayPreviousScore(int score)
        {
            previousscore = score;
            PreviusScoreT.text = $"Previous: {ScoreDisplay.DeserializeInt(score)}";
        }

        public void DisplayLastScore(int score)
        {
            if (previousscore < score)
                LastScoreT.color = Color.green;
            LastScoreT.text = $"Score: {ScoreDisplay.DeserializeInt(score)}";
        }
    }
}
