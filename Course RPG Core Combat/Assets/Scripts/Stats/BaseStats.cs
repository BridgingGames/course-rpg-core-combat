using System;
using UnityEngine;

namespace RPG.Stats
{
    public class BaseStats : MonoBehaviour
    {
        [Range(1, 99)][SerializeField] int startingLevel = 1;
        [SerializeField] CharacterClass characterClass;
        [SerializeField] Progression progression = null;
        [SerializeField] GameObject levelUpParticleEffect = null;

        public event Action onLevelUp;

        Experience experience;

        int currentLeveL = 0;

        private void Start()
        {
            experience = GetComponent<Experience>();
            currentLeveL = CalculateLevel();
            if(experience != null)
            {
                experience.onExperienceGained += UpdateLevel;
            }
        }

        private void UpdateLevel()
        {
            int newLevel = CalculateLevel();
            if (newLevel > currentLeveL)
            {
                currentLeveL = newLevel;
                LevelUpEffect();
                onLevelUp();
            }
        }

        private void LevelUpEffect()
        {
            Instantiate(levelUpParticleEffect, transform);
        }

        public float GetStat(Stat stat)
        {
            return progression.GetStat(stat, characterClass, GetLevel());
        }

        public int GetLevel()
        {
            if(currentLeveL < 1)
            {
                currentLeveL = CalculateLevel();
            }
            return currentLeveL;
        }

        public int CalculateLevel()
        {
            if (experience == null) return startingLevel;

            float currentExp = experience.GetExperiencePoints();
            int pernultimateLevel = (int)progression.GetLevels(Stat.ExperienceToLevelUp, characterClass);
            for (int level = 1; level <= pernultimateLevel; level++)
            {
                float expToLevelUp = progression.GetStat(Stat.ExperienceToLevelUp, characterClass, level);
                
                if (expToLevelUp > currentExp)
                {
                    return level;
                }
            }

            return pernultimateLevel + 1;
        }
    }
}