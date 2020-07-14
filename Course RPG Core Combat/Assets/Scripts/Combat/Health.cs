using UnityEngine;

namespace RPG.Combat
{
    public class Health : MonoBehaviour
    {
        [SerializeField] float _health = 100;

        public void TakeDamage(float damage)
        {
            _health =  Mathf.Max(_health - damage, 0);
            print(_health);
        }
    }
}