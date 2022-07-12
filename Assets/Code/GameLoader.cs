using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using DataContainers;

public class GameLoader : MonoBehaviour
{
    [SerializeField]
    private MenuEngine.SceneLoader sceneLoader;

    [SerializeField]
    private ChoosedMapData choosedMapData;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void LoadGame()
    {
        sceneLoader.LoadScene(choosedMapData.ChoosedMapName);
    }
}
