using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    private float damageTimer;
    public int damageTick;
    public int attackCooldown;

    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other) {
        damageTimer -= Time.deltaTime;
        
        if (damageTimer <= 0f) {
            damageTimer += attackCooldown;

            PlayerCharacterController playerCharacterController = other.GetComponent<PlayerCharacterController>();
            if (playerCharacterController != null) {
                playerCharacterController.Damage(damageTick);
            }
        }
    }
}
