using UnityEngine;

namespace RPG.Core
{
    public class PersistentObjectSpawner : MonoBehaviour
    {
        static bool HasSpawned = false;

        [SerializeField] GameObject persistentObjectPrefab;
        
        // Check if Persistent Object already exists, if not, spawn It and flag as already spawned.
        private void Awake()
        {
            if (HasSpawned) return;

            SpawnPersistentObjects();
            HasSpawned = true;
        }

        // Spawn Persistent Object and set It as do not destroy on Load.
        private void SpawnPersistentObjects()
        {
            GameObject persistentObject = Instantiate(persistentObjectPrefab);
            DontDestroyOnLoad(persistentObject);
        }
    }
}