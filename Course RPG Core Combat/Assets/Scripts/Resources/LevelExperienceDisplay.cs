using RPG.Stats;
using UnityEngine;
using UnityEngine.UI;

namespace RPG.Resources
{
    public class LevelExperienceDisplay : MonoBehaviour
    {
        BaseStats baseStats;
        Experience experience;

        private void Awake()
        {
            baseStats = GameObject.FindWithTag("Player").GetComponent<BaseStats>();
            experience = GameObject.FindWithTag("Player").GetComponent<Experience>();
        }

        private void Update()
        {
            GetComponent<Text>().text = "Player Level [" + baseStats.GetLevel() + "] Exp [" + experience.GetExperiencePoints() + "]";
        }
    }
}