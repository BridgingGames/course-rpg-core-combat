using UnityEngine;
using UnityEngine.UI;

namespace RPG.Combat
{
    public class EnemyHealthDisplay : MonoBehaviour
    {
        Fighter fighter;

        private void Awake()
        {
            fighter = GameObject.FindWithTag("Player").GetComponent<Fighter>();
        }

        private void Update()
        {
            if(fighter.GetTarget() == null)
            {
                GetComponent<Text>().text = "No [Enemy] selected.";
            }
            else
            {
                GetComponent<Text>().text = "Player Health [" + fighter.GetTarget().GetHealthMinMax()[0] + "/" + fighter.GetTarget().GetHealthMinMax()[1] + "] [" + Mathf.Round(fighter.GetTarget().GetHealthPercentage() * 10) / 10 + " %]";
            }
        }
    }
}