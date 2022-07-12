using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace DataContainers
{
    [CreateAssetMenu(fileName = "ScoreData", menuName = "Score data", order = 1)]
    public class ScoreData : ScriptableObject
    {
        [SerializeField]
        private string mapName;

        public string MapName { get { return mapName; } }

        //public int MapIndex { get { return mapScene.buildIndex; } }

        private int score;

        public int Score
        {
            get { return score; }
            set
            {
                if (value >= 0)
                {
                    score = value;
                }
            }
        }
    }
}
