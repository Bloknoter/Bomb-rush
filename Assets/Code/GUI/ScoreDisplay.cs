using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using DataContainers;

namespace GUI
{
    public class ScoreDisplay : MonoBehaviour, IChoosedMapObserver
    {
        [SerializeField]
        private ScoreDataList scoreDataLst;

        [SerializeField]
        private ChoosedMapData choosedMapData;

        [SerializeField]
        private Text scoreT;

        private ScoreData selectedScoreData;

        void Start()
        {
            choosedMapData.AddListener(this);
            SelectScoreData(choosedMapData.ChoosedMapName);
            DisplayScore(selectedScoreData.Score);
        }

        void Update()
        {

        }

        public void OnChoosedMapChanged(string newMapName)
        {
            //Debug.Log($"New map: {newMapName}");
            SelectScoreData(newMapName);
            //Debug.Log($"Selected score data: {selectedScoreData.MapName}, score: {selectedScoreData.Score}");
            DisplayScore(selectedScoreData.Score);
        }

        private void SelectScoreData(string mapName)
        {
            selectedScoreData = scoreDataLst.FindScoreData(mapName);
        }

        private void DisplayScore(int value)
        {
            if (value > 0)
                scoreT.text = "Best result : " + DeserializeInt(value);
            else
                scoreT.text = "Best result : --:--";

        }

        public static string DeserializeInt(int value)
        {
            string result = "";
            int min = value / 60;
            result += $"{min}:";
            int sec = value - min * 60;
            if (sec < 10)
                result += "0";
            result += $"{sec}";
            return result;
        }

        private void OnDestroy()
        {
            choosedMapData.RemoveListener(this);
        }
    }
}
