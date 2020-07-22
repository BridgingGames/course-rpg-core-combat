using UnityEngine;
using System.IO;
using System.Text;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.Collections.Generic;

namespace RPG.Saving
{
    public class SavingSystem : MonoBehaviour
    {

        public void Save(string saveFile)
        {
            string path = GetPathFromSaveFile(saveFile);
            print("Saving to " + path);

            using (FileStream stream = File.Open(path, FileMode.Create))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(stream, CaptureState());
            } 
        }

        public void Load(string saveFile)
        {
            string path = GetPathFromSaveFile(saveFile);
            print("Loading from " + GetPathFromSaveFile(saveFile));

            using (FileStream stream = File.Open(path, FileMode.Open))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                RestoreState(formatter.Deserialize(stream));
            }
        }

        private object CaptureState()
        {
            Dictionary<string, object> capture = new Dictionary<string, object>();
            foreach(SaveableEntity entity in FindObjectsOfType<SaveableEntity>())
            {
                capture[entity.GetUniqueIdentifier()] = entity.CaptureState();
            }
            return capture;
        }

        private void RestoreState(object state)
        {
            Dictionary<string, object> restore = (Dictionary<string, object>)state;

            foreach (SaveableEntity entity in FindObjectsOfType<SaveableEntity>())
            {
                entity.RestoreState(restore[entity.GetUniqueIdentifier()]);
            }
        }

        private string GetPathFromSaveFile(string saveFile)
        {
            return Path.Combine(Application.persistentDataPath, saveFile + ".sav");
        }
    }
}