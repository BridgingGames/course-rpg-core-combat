/* Additional */
using UnityEngine;

namespace RPG.Core
{
    public class Status : MonoBehaviour
    {
        [SerializeField] bool isHidden = false;

        private void OnTriggerEnter(Collider col)
        {
            if (col.tag == "Hide Spot")
            {
                isHidden = true;
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

