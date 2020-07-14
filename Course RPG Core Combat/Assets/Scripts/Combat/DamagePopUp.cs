// Additional Content
using UnityEngine;
using TMPro;

namespace RPG.Combat
{
    public class DamagePopUp : MonoBehaviour
    {
        private TextMeshPro _textMesh;

        private void Awake()
        {
            _textMesh = GetComponent<TextMeshPro>();
        }

        public void Setup(float damgeAmount)
        {
            _textMesh.SetText(damgeAmount.ToString());
        }
    }
}