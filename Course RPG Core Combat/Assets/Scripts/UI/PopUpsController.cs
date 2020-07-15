// Additional Content
using UnityEngine;

namespace RPG.UI
{
    public class PopUpsController : MonoBehaviour
    {
        [SerializeField] Canvas _canvas = null;
        [SerializeField] Transform _playerDamagePopUpText = null;
        [SerializeField] Transform _enemyDamagePopUpText = null;

        public void PlayerDamagePopUp(float damage, Transform target)
        {
            Transform popUp = Instantiate(_playerDamagePopUpText);
            popUp.transform.SetParent(_canvas.transform, false);

            DamagePopUp damagePopUp = popUp.GetComponent<DamagePopUp>();
            damagePopUp.Setup(damage, target);
        }

        public void EnemyDamagePopUp(float damage)
        {
            Transform popUp = Instantiate(_enemyDamagePopUpText);
            popUp.transform.SetParent(_canvas.transform, false);

            DamagePopUp damagePopUp = popUp.GetComponent<DamagePopUp>();
            damagePopUp.Setup(damage, transform);
        }
    }
}