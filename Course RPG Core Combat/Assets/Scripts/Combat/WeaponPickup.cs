using UnityEngine;

namespace RPG.Combat
{
    public class WeaponPickup : MonoBehaviour
    {
        [SerializeField] Weapon pickupWeapon = null;

        private void OnTriggerEnter(Collider other)
        {
            if(other.tag == "Player")
            {
                other.GetComponent<Fighter>().EquipWeapon(pickupWeapon);
                Destroy(gameObject);
            }
        }
    }
}
