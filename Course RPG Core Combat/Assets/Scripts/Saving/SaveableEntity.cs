using UnityEngine;
using UnityEditor;
using System.Collections.Generic;

namespace RPG.Saving
{
    [ExecuteAlways]
    public class SaveableEntity : MonoBehaviour
    {
        [SerializeField] string uniqueIdentifier = "";
        static Dictionary<string, SaveableEntity> globalLookUp = new Dictionary<string, SaveableEntity>();

        public string GetUniqueIdentifier()
        {
            return uniqueIdentifier;
        }

        public object CaptureState()
        {
            Dictionary<string, object> state = new Dictionary<string, object>();
            foreach (ISaveable saveable in GetComponents<ISaveable>())
            {
                state[saveable.GetType().ToString()] = saveable.CaptureState();
            }
            return state;
        }

        public void RestoreState(object state)
        {
            Dictionary<string, object> stateDict = (Dictionary<string, object>)state;
            foreach (ISaveable saveable in GetComponents<ISaveable>())
            {
                string type = saveable.GetType().ToString();
                if(stateDict.ContainsKey(type))
                {
                    saveable.RestoreState(stateDict[type]);
                }
            }
        }

#if UNITY_EDITOR
        private void Update()
        {
            print("Editing"); 

            if (Application.IsPlaying(gameObject)) return;
            if (string.IsNullOrEmpty(gameObject.scene.path)) return;

            SerializedObject serializedObject = new SerializedObject(this);
            SerializedProperty property = serializedObject.FindProperty("uniqueIdentifier");

            if (string.IsNullOrEmpty(property.stringValue) || !IsUnique(property.stringValue))
            {
                property.stringValue = System.Guid.NewGuid().ToString();
                serializedObject.ApplyModifiedProperties();
            }

            globalLookUp[property.stringValue] = this;
        }

        private bool IsUnique(string candidate)
        {
            if (!globalLookUp.ContainsKey(candidate)) return true;
            if (globalLookUp[candidate] == this) return true;
            if (globalLookUp[candidate] == null)
            {
                globalLookUp.Remove(candidate);
                return true;
            }
            if (globalLookUp[candidate].GetUniqueIdentifier() != candidate)
            {
                globalLookUp.Remove(candidate);
                return true;
            }

            return false;
        }
#endif
    }
}