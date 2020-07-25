// Additional Content
using UnityEngine;
using RPG.Combat;

namespace RPG.Core
{
    public class NEEDREVISIONStatus : MonoBehaviour
    {
        private bool isHidden;
        [SerializeField] private Material playerMaterial;

        private void Start()
        {
            // Set default values.
            isHidden = false;
            playerMaterial = null;
        }

        // Return if character is hidden or not.
        public bool IsHidden()
        {
            return isHidden;
        }

        // If character is in a hide spot and not in combat, hide It;
        // also, change character shader and play hiding sound effect.
        //private void OnTriggerEnter(Collider other)
        //{
        //    if (other.tag == "Hide Spot" && !GetComponent<Fighter>().IsInCombat())
        //    {
        //        isHidden = true;
        //        playerMaterial.shader = Shader.Find("Legacy Shaders/Transparent/Diffuse");
        //        playerMaterial.color = new Color(0.5019608f, 0.5019608f, 0.5019608f, 0.3882353f);
        //    }
        //}

        // If character exits a hide spot, unhide It and change Its shader.
        private void OnTriggerExit(Collider other)
        {
            if (other.tag == "Hide Spot")
            {
                isHidden = false;
                playerMaterial.shader = Shader.Find("Legacy Shaders/Self-Illumin/Diffuse");
            }
        }
    }
}

