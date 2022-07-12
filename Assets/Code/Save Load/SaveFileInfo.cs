using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

namespace DataContainers
{
    [CreateAssetMenu(fileName ="SaveFileInfo", menuName = "Save file info", order = 0)]
    public class SaveFileInfo : ScriptableObject
    {
        private const string FILE_NAME = "savdat.dat";

        public string FilePath(string mapName)
        {
            return Path.Combine(Application.persistentDataPath, mapName + FILE_NAME);
        }
    }
}
