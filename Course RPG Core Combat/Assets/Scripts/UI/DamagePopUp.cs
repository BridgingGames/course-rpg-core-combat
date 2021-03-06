﻿/* Additional */
using UnityEngine;
using UnityEngine.UI;

namespace RPG.UI
{
    public class DamagePopUp : MonoBehaviour
    {
        Animator _animator;
        Text _damageText;

        Transform _target = null;

        private void Awake()
        {
            _animator = GetComponentInChildren<Animator>();
            _damageText = GetComponentInChildren<Text>();
        }

        private void Update()
        {
            if(_target != null)
            {
                Vector3 screenPosition = Camera.main.WorldToScreenPoint(_target.position);
                transform.position = screenPosition;
            }
        }

        public void Setup(float damage, Transform target)
        {
            _target = target;
            _damageText.text = damage.ToString();
            AnimatorClipInfo[] clipInfo = _animator.GetCurrentAnimatorClipInfo(0);
            Destroy(gameObject, clipInfo[0].clip.length);
        }
    }
}