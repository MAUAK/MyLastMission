using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTerritory : MonoBehaviour{
    public BoxCollider territory;
    GameObject player;
    bool playerInTerritory;

    public GameObject enemy;
    BasicEnemy basicEnemy;

    // Start is called before the first frame update
    void Start(){
        player = GameObject.FindGameObjectWithTag ("Player");
        basicEnemy = enemy.GetComponent <BasicEnemy> ();
        playerInTerritory = false;
    }

    // Update is called once per frame
    void Update(){
       if (playerInTerritory == true){
        basicEnemy.MoveToPlayer();
       }

       if (playerInTerritory == false){
        basicEnemy.Rest();
       }
    }

    void OnTriggerEnter (Collider other){
        if (other.gameObject == player){
            playerInTerritory = true;
        }
    }

    void OnTriggerExit (Collider other){
        if (other.gameObject == player){
            playerInTerritory = false;
        }
    }
}