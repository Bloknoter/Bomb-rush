using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace DataContainers
{
    [CreateAssetMenu(fileName = "ChoosedMapData", menuName = "Choosed map data")]
    public class ChoosedMapData : ScriptableObject
    {

        #region Observers code

        private List<IChoosedMapObserver> listeners = new List<IChoosedMapObserver>();

        public void AddListener(IChoosedMapObserver observer)
        {
            listeners.Add(observer);
        }

        public void RemoveListener(IChoosedMapObserver observer)
        {
            listeners.Remove(observer);
        }

        private void InvokeOnChangedEvent()
        {
            for (int i = 0; i < listeners.Count; i++)
            {
                if (listeners[i] != null)
                    listeners[i].OnChoosedMapChanged(choosedMapName);
                else
                {
                    listeners.RemoveAt(i);
                    i--;
                }
            }
        }

        #endregion


        [SerializeField]
        private string defaultMapName;

        private string choosedMapName = "";

        public string ChoosedMapName
        {
            get 
            {
                if (choosedMapName != null && choosedMapName != "")
                    return choosedMapName;
                else
                    return defaultMapName;
            }
            set
            {
                //Debug.Log($"New value: {value}");
                //Debug.Log($"Current value : {choosedMapName}");
                string newvalue = defaultMapName;
                if(value != null && value != "")
                {
                    newvalue = value;
                }
                if(choosedMapName != newvalue)
                {
                    choosedMapName = newvalue;
                    //Debug.Log($"On Changed, new map : {choosedMapName}");
                    InvokeOnChangedEvent();
                }
            }
        }
    }

    public interface IChoosedMapObserver
    {
        void OnChoosedMapChanged(string newMapName);
    }
}
