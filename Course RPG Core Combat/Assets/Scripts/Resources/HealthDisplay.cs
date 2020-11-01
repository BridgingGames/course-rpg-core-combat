using UnityEngine;
using UnityEngine.UI;

namespace RPG.Resources
{
    public class HealthDisplay : MonoBehaviour
    {
        Health health;

        private void Awake()
        {
            health = GameObject.FindWithTag("Player").GetComponent<Health>();
        }

        private void Update()
        {
            GetComponent<Text>().text = "Player Health [" + health.GetHealthMinMax()[0] + "/" + health.GetHealthMinMax()[1] + "] [" + Mathf.Round(health.GetHealthPercentage() * 10) / 10 + " %]";
        }
    }
}