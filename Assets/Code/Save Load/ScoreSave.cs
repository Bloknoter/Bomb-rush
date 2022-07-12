using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

using DataContainers;


namespace SaveLoad
{
    public class ScoreSave : MonoBehaviour
    {
        [SerializeField]
        private SaveFileInfo fileInfo;

        [SerializeField]
        private ScoreDataList scoreDataList;

        [SerializeField]
        private ChoosedMapData choosedMapData;

        [SerializeField]
        private TimerEngine.Timer timer;

        [SerializeField]
        private Health playerHealth;

        [SerializeField]
        private MenuEngine.MenuController menuController;

        [SerializeField]
        private GUI.FinishResultsDisplay resultsDisplay;

        private ScoreData selectedScoreData;

        void Start()
        {
            playerHealth.OnValueChangedEvent += OnHealthChanged;
            selectedScoreData = scoreDataList.FindScoreData(choosedMapData.ChoosedMapName);
        }

        void Update()
        {

        }

        private void OnHealthChanged(int previousvalue, int newvalue)
        {
            if (newvalue <= 0 && previousvalue > 0)
            {
                timer.Stop();
                int lastscore = timer.TimeCount;
                resultsDisplay.DisplayPreviousScore(selectedScoreData.Score);
                if (selectedScoreData.Score < lastscore)
                    selectedScoreData.Score = lastscore;
                FileStream stream = new FileStream(fileInfo.FilePath(selectedScoreData.MapName), FileMode.OpenOrCreate);
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(stream, selectedScoreData.Score);
                stream.Close();
                resultsDisplay.DisplayLastScore(lastscore);
                menuController.SetPage("Finish");
            }
        }
    }
}
