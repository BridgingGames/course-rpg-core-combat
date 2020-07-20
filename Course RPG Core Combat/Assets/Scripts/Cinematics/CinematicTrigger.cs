using UnityEngine;
using UnityEngine.Playables;

namespace RPG.Cinematics
{
    public class CinematicTrigger : MonoBehaviour
    {
        bool wasTriggered = false;

        private void Update()
        {
            if(GetComponent<PlayableDirector>().time >= 14.5f)
            {
                GetComponent<PlayableDirector>().Stop();
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (!wasTriggered && other.tag == "Player")
            {
                wasTriggered = true;
                GetComponent<PlayableDirector>().Play();
            }
        }
    }
}