// Additional Content
using UnityEngine;

namespace RPG.UI
{
    public class PopUpsController : MonoBehaviour
    {
        private Canvas _canvas;
        [SerializeField] Transform _playerDamagePopUpText = null;

        public void DamagePopUp(float damage, Transform target)
        {
            _canvas = GameObject.FindGameObjectWithTag("Canvas").GetComponent<Canvas>();
            Transform popUp = Instantiate(_playerDamagePopUpText);
            popUp.transform.SetParent(_canvas.transform, false);
            DamagePopUp damagePopUp = popUp.GetComponent<DamagePopUp>();
            damagePopUp.Setup(damage, transform);
        }
    }
}