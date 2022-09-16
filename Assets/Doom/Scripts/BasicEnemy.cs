using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemy : MonoBehaviour
{

    public Transform target; 
    public float speed = 3f;
    public float attackRange = 1f;
    public int attackDamage = 1;
    public float timeBetweenAttacks;

    // Start is called before the first frame update
    void Start()
    {
        Rest ();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MoveToPlayer(){
        transform.LookAt(target.position);
        transform.Rotate(new Vector3 (0, -90, 0), Space.Self);

        if(Vector3.Distance(transform.position, target.position) > attackRange){
            transform.position = Vector3.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
        }
    }

    public void Rest(){

    }
}
