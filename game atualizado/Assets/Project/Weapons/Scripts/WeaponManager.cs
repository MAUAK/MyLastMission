using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Lanterninha
{
    public class WeaponManager : MonoBehaviour
    {
        public Transform WeaponHolder;

        private void OnTriggerEnter(Collider other)
        {
            if(other.CompareTag("ammo"))
            {
                if(other.TryGetComponent(out AmmoInGround ammo))
                {
                    foreach (Transform item in WeaponHolder)
                    {
                        WeaponInHand weapon = item.GetComponent<WeaponInHand>();
                        weapon.AddAmmo(ammo.ammo, ammo.weaponType);
                    }
                }

                Destroy(other.gameObject);
            }
        }
    }
}


