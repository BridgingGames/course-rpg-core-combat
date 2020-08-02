/* Additional */
using UnityEngine;

namespace RPG.UI
{
    public class PopUpsController : MonoBehaviour
    {
        private Canvas _canvas;
        [SerializeField] private Transform _damagePopUpText = null;

        public void DamagePopUp(float damage, Transform target)
        {
            _canvas = GameObject.FindGameObjectWithTag("Canvas").GetComponent<Canvas>();

            Transform popUp = Instantiate(_damagePopUpText);
            popUp.transform.SetParent(_canvas.transform, false);
            DamagePopUp damagePopUp = popUp.GetComponent<DamagePopUp>();
            damagePopUp.Setup(damage, target);
        }
    }
}