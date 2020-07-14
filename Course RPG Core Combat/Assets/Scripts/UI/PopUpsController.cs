// Additional Content
using UnityEngine;

namespace RPG.UI
{
    public class PopUpsController : MonoBehaviour
    {
        [SerializeField] Canvas _canvas = null;
        [SerializeField] Transform _damagePopUpText = null;

        public void DamagePopUp(float damage, Transform target)
        {
            Transform popUp = Instantiate(_damagePopUpText);
            popUp.transform.SetParent(_canvas.transform, false);

            DamagePopUp damagePopUp = popUp.GetComponent<DamagePopUp>();
            damagePopUp.Setup(damage, target);
        }
    }
}