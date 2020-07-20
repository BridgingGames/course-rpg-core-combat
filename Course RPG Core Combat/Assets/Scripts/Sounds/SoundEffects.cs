/* Additional */
using UnityEngine;

namespace RPG.Sounds
{
    public class SoundEffects : MonoBehaviour
    {
        [SerializeField] AudioClip stepGrass;
        [SerializeField] AudioClip[] hitUnarmed = new AudioClip[5];
        [SerializeField] AudioClip hiding;
        [SerializeField] AudioClip healing;
        [SerializeField] AudioClip revive;
        [SerializeField] AudioClip death;
        private AudioSource audioSource;

        void Start()
        {
            audioSource = GetComponentInChildren<AudioSource>();
        }

        public void PlayDeathSoundEffect()
        {
            audioSource.PlayOneShot(death);
        }

        public void PlayReviveSoundEffect()
        {
            audioSource.PlayOneShot(revive);
        }

        public void PlayHealingSoundEffect()
        {
            audioSource.PlayOneShot(healing);
        }

        public void PlayHidingSoundEffect()
        {
            audioSource.PlayOneShot(hiding);
        }

        public void PlayUnarmedHitSoundEffect()
        {
            int hit = Random.Range(0, 5);
            audioSource.PlayOneShot(hitUnarmed[hit]);
        }

        public void PlayStepSoundEffect()
        {
            audioSource.PlayOneShot(stepGrass);
        }
    }
}
