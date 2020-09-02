using System;
using System.Collections.Generic;
using UnityEngine;

namespace RPG.Stats
{
    [CreateAssetMenu(fileName = "Progression", menuName = "Stats/New Progression", order = 0)]
    public class Progression : ScriptableObject
    {
        [SerializeField] ProgressionCharacterClass[] characterClasses = null;

        Dictionary<CharacterClass, Dictionary<Stat, float[]>> lookUpTable = null;

        private void BuildLookUp()
        {
            if (lookUpTable != null) return;

            lookUpTable = new Dictionary<CharacterClass, Dictionary<Stat, float[]>>();

            foreach (ProgressionCharacterClass progressionClass in characterClasses)
            {
                var statLookUpTable = new Dictionary<Stat, float[]>();

                foreach (ProgressionStat progressionStat in progressionClass.stats)
                {
                    statLookUpTable[progressionStat.stat] = progressionStat.levels;
                }

                lookUpTable[progressionClass.characterClass] = statLookUpTable;
            }
        }

        public float GetStat(Stat stat, CharacterClass characterClass, int level)
        {
            BuildLookUp();

            return lookUpTable[characterClass][stat][level];

            //foreach (ProgressionCharacterClass progressionClass in characterClasses)
            //{
            //    if (progressionClass.characterClass != characterClass) continue;

            //    foreach (ProgressionStat progressionStat in progressionClass.stats)
            //    {
            //        if (progressionStat.stat != stat) continue;

            //        if (progressionStat.levels.Length < level) continue;

            //        return progressionStat.levels[level - 1];
            //    }
            //}
            //return 0;
        }

        [System.Serializable]
        class ProgressionCharacterClass
        {
            public CharacterClass characterClass;
            public ProgressionStat[] stats;
        }

        [System.Serializable]
        class ProgressionStat
        {
            public Stat stat;
            public float[] levels;
        }
    }
}