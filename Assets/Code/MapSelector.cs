using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using DataContainers;

public class MapSelector : MonoBehaviour
{
    [SerializeField]
    private ChoosedMapData choosedMapData;

    [SerializeField]
    private MapData[] mapsData;

    [SerializeField]
    private Text mapNameT;

    private int selectedMapID = 0;

    void Start()
    { 
        SelectMap(0);
    }

    void Update()
    {
        
    }

    private void SelectMap(int newID)
    {
        mapsData[selectedMapID].MapObject.SetActive(false);
        selectedMapID = newID;
        mapsData[selectedMapID].MapObject.SetActive(true);
        choosedMapData.ChoosedMapName = mapsData[selectedMapID].scoreData.MapName;
        mapNameT.text = choosedMapData.ChoosedMapName;
    }

    public void OnLeftClicked()
    {
        if (selectedMapID == 0)
            SelectMap(mapsData.Length - 1);
        else
            SelectMap(selectedMapID - 1);
    }

    public void OnRightClicked()
    {
        if (selectedMapID == mapsData.Length - 1)
            SelectMap(0);
        else
            SelectMap(selectedMapID + 1);
    }

    [System.Serializable]
    private class MapData
    {
        public GameObject MapObject;

        public ScoreData scoreData;
    }
}
