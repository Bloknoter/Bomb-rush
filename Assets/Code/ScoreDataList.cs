using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace DataContainers
{
    [CreateAssetMenu(fileName = "ScoreDataList", menuName = "Score data list")]
    public class ScoreDataList : ScriptableObject
    {
        [SerializeField]
        private ScoreData[] scoresData;

        public ScoreData[] ScoresData { get { return scoresData; } }

        public ScoreData FindScoreData(string mapName)
        {
            for(int i = 0; i < scoresData.Length;i++)
            {
                if (scoresData[i].MapName == mapName)
                    return scoresData[i];
            }
            return null;
        }
    }
}
