/* Additional */
using UnityEngine;
using RPG.Sounds;
using RPG.Combat;

namespace RPG.Core
{
    public class Status : MonoBehaviour
    {
        [SerializeField] bool isHidden = false;

        private void OnTriggerEnter(Collider col)
        {
            if (col.tag == "Hide Spot" && !GetComponent<Fighter>().IsInCombat())
            {
                isHidden = true;
                GetComponent<SoundEffects>().PlayHidingSoundEffect();
            }
        }

        private void OnTriggerExit(Collider col)
        {
            if (col.tag == "Hide Spot")
            {
                isHidden = false;
            }
        }

        public bool CheckIfHidden()
        {
            return isHidden;
        }
    }
}

