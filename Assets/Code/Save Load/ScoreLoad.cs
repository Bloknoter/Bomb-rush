using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

using DataContainers;


namespace SaveLoad
{
    public class ScoreLoad : MonoBehaviour
    {
        [SerializeField]
        private SaveFileInfo fileInfo;

        [SerializeField]
        private ScoreDataList scoreDataList;

        private void OnEnable()
        {
            //Debug.Log($"Path: {fileInfo.FilePath($"{scoreDataList.ScoresData[0].MapName}")}");
            for (int i = 0; i < scoreDataList.ScoresData.Length; i++)
            {
                //Debug.Log($"Loading score data of map: {scoreDataList.ScoresData[i].MapName}");
                if (File.Exists(fileInfo.FilePath(scoreDataList.ScoresData[i].MapName)))
                {
                    //Debug.Log($"File exists");
                    FileStream stream = new FileStream(fileInfo.FilePath(scoreDataList.ScoresData[i].MapName), FileMode.Open);
                    BinaryFormatter formatter = new BinaryFormatter();
                    scoreDataList.ScoresData[i].Score = (int)formatter.Deserialize(stream);
                    stream.Close();
                }
                else
                {
                    //Debug.Log($"File does not exist");
                    scoreDataList.ScoresData[i].Score = 0;
                }
            }
        }
    }
}
