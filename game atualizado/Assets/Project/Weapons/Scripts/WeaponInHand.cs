using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace Lanterninha
{
    public class WeaponInHand : MonoBehaviour
    {
        [SerializeField] private WeaponSO weaponAsset;
        [SerializeField] private LayerMask shootLayer;
        [Space]
        [SerializeField] private Image weaponGFX;
        //[SerializeField] private TextMeshProUGUI txtAmmo;

        public Text txtAmmo;
        private Camera cam;
        private int currentAmmo;
        private float nextTimeToShoot = 0f;
        private Coroutine shootCoroutine;

        private void Start()
        {
            cam = Camera.main;
            weaponGFX.sprite = weaponAsset.idleSprite;
            currentAmmo = weaponAsset.defaultAmmo;
            txtAmmo.text = currentAmmo.ToString();
        }

        private void Update()
        {
            if (PlayerHealth.isDead) return;

            if (Input.GetButtonDown("Fire1") && Time.time >= nextTimeToShoot)
            {
                nextTimeToShoot = Time.time + 1f / weaponAsset.fireRate;
                Shoot();
            }
        }

        private void Shoot()
        {
            if (currentAmmo == 0) return;

            currentAmmo--;
            txtAmmo.text = currentAmmo.ToString();

            if (shootCoroutine != null)
                StopCoroutine(shootCoroutine);

            shootCoroutine = StartCoroutine(shootAnimation());
            Debug.Log("pew");
            RaycastHit hit;
            if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, 999f, shootLayer))
            {
                Debug.Log(hit.transform.name);
                hit.transform.GetComponent<EnemyHealth>().TakeDamage(weaponAsset.damage);
            }
        }

        private IEnumerator shootAnimation()
        {
            weaponGFX.sprite = weaponAsset.shootSprite;
            yield return new WaitForSeconds(0.15f);
            weaponGFX.sprite = weaponAsset.postShootSprite;
            yield return new WaitForSeconds(0.15f);
            weaponGFX.sprite = weaponAsset.idleSprite;
        }

        public void AddAmmo(int ammo, WeaponType type)
        {
            if(type == weaponAsset.weaponType)
            {
                currentAmmo += ammo;
                if(currentAmmo > weaponAsset.maxAmmo)
                {
                    currentAmmo = weaponAsset.maxAmmo;
                }

                txtAmmo.text = currentAmmo.ToString();
            }
        }
    }
}


