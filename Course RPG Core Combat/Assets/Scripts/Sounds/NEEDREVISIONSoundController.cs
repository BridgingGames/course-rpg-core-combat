/* Additional */
using UnityEngine;

namespace RPG.Sounds
{
    public class NEEDREVISIONSoundController: MonoBehaviour
    {
        [Header("Background Music")]
        [Tooltip("Main Level music.")] [SerializeField] private AudioClip _mainMusic = null;
        [Space]

        [Header("Sound Effects")]
        [SerializeField] private AudioClip stepGrass = null;
        [Tooltip("All unarmed hit sound effects.")] [SerializeField] private AudioClip[] hitUnarmed = new AudioClip[5];
        [SerializeField] private AudioClip hiding = null;
        [SerializeField] private AudioClip healing = null;
        [SerializeField] private AudioClip revive = null;
        [SerializeField] private AudioClip death = null;

        private AudioSource _sfxAudioSource = null;
        private AudioSource _bgmAudioSource = null;

        void Start()
        {
            _sfxAudioSource = gameObject.transform.Find("SFX Holder").GetComponent<AudioSource>();
            if (gameObject.tag == "Player")
            {
                _bgmAudioSource = gameObject.transform.Find("BGM Holder").GetComponent<AudioSource>();
                PlayMainLevelMusic();
            }
        }

        public void PlayMainLevelMusic()
        {
            _bgmAudioSource.clip = _mainMusic;
            _bgmAudioSource.Play();
        }

        public void PlayDeathSoundEffect()
        {
            _sfxAudioSource.PlayOneShot(death);
        }

        public void PlayReviveSoundEffect()
        {
            _sfxAudioSource.PlayOneShot(revive);
        }

        public void PlayHealingSoundEffect()
        {
            _sfxAudioSource.PlayOneShot(healing);
        }

        public void PlayHidingSoundEffect()
        {
            _sfxAudioSource.PlayOneShot(hiding);
        }

        public void PlayUnarmedHitSoundEffect()
        {
            int hit = Random.Range(0, 5);
            _sfxAudioSource.PlayOneShot(hitUnarmed[hit]);
        }

        public void PlayStepSoundEffect()
        {
            _sfxAudioSource.PlayOneShot(stepGrass);
        }
    }
}
