using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Lanterninha
{
    [CreateAssetMenu(menuName = "Assets/weapon", fileName = "New weapon")]
    public class WeaponSO : ScriptableObject
    {
        public string weaponName;
        public WeaponType weaponType;
        public Sprite idleSprite;
        public Sprite shootSprite;
        public Sprite postShootSprite;
        public float fireRate;
        public int maxAmmo;
        public int defaultAmmo;
        public int damage;
    }

    public enum WeaponType
    {
        revolver,
        rifle
    }
}

