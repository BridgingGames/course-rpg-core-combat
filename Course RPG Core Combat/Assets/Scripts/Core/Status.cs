/* Additional */
using UnityEngine;
using RPG.Sounds;
using RPG.Combat;

namespace RPG.Core
{
    public class Status : MonoBehaviour
    {
        [SerializeField] bool isHidden = false;
        [SerializeField] Material playerMaterial;

        private void OnTriggerEnter(Collider col)
        {
            if (col.tag == "Hide Spot" && !GetComponent<Fighter>().IsInCombat())
            {
                isHidden = true;
                playerMaterial.shader = Shader.Find("Legacy Shaders/Transparent/Diffuse");
                playerMaterial.color = new Color(0.5019608f, 0.5019608f, 0.5019608f, 0.3882353f);
                GetComponent<SoundController>().PlayHidingSoundEffect();
            }
        }

        private void OnTriggerExit(Collider col)
        {
            if (col.tag == "Hide Spot")
            {
                playerMaterial.shader = Shader.Find("Legacy Shaders/Self-Illumin/Diffuse");
                isHidden = false;
            }
        }

        public bool CheckIfHidden()
        {
            return isHidden;
        }
    }
}

