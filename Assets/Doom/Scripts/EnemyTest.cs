using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTest : MonoBehaviour
{
    private HealthSystem healthSystem;
    // Área de perseguição
    public BoxCollider territory;
    public float minDistance;
    public GameObject target; 
    public float speed;
    bool playerInTerritory;

    // Start is called before the first frame update
    void Start()
    {
        playerInTerritory = false;

    }

    // Update is called once per frame
    void Update()
    {
        if (playerInTerritory == true && Vector3.Distance(transform.position, target.transform.position) > minDistance){
            transform.position = Vector3.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
        }     
    }
    // Enquanto o objeto continuar dentro da área do box collider 
    void OnTriggerStay (Collider other){
        if (other.gameObject == target){
            playerInTerritory = true;
        }
    }
    // Ao sair da área do box collider, caso queira deixar perseguição infinita é só remover OnTriggerExit
    void OnTriggerExit (Collider other){
        if (other.gameObject == target){
            playerInTerritory = false;
        }
    }

    

}
