using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace Lanterninha
{
    [RequireComponent(typeof(NavMeshAgent))]
    public class EnemyBehaviour : MonoBehaviour
    {
        [SerializeField] private LayerMask groundLayer;
        [SerializeField] private LayerMask playerLayer;
        [SerializeField] private float walkDistance;
        [SerializeField] private float timeBtwAttacks;
        [SerializeField] private float viewRange;
        [SerializeField] private float attackRange;
        [SerializeField] private int attackDamage;
        [SerializeField] private Transform shootPoint;
        [SerializeField] private bool showGizmos;

        private Transform target;
        private NavMeshAgent agent;

        private Vector3 walkPoint;
        private bool walkPointSet;

        private bool hasAttacked;
    

        private bool hasPlayerInView;
        private bool hasPlayerInAttack;
        private Transform _transform;

        private void Start()
        {
            target = GameObject.FindGameObjectWithTag("Player").transform;
            agent = GetComponent<NavMeshAgent>();
            _transform = transform;
        }

        private void Update()
        {
            if (PlayerHealth.isDead) return;

            hasPlayerInView = Physics.CheckSphere(_transform.position, viewRange, playerLayer);
            hasPlayerInAttack = Physics.CheckSphere(_transform.position, attackRange, playerLayer);

            if (!hasPlayerInView && !hasPlayerInAttack)
                Patrol();
            else if(hasPlayerInView && !hasPlayerInAttack)
                ChasePlayer();
            else if(hasPlayerInView && hasPlayerInAttack)
                AttackPlayer();
        }

        private void Patrol()
        {
            if (!walkPointSet)
                SearchWalkPoint();

            if(walkPointSet)
            {
                agent.SetDestination(walkPoint);
            }

            Vector3 distanceToWalkPoint = _transform.position - walkPoint;
            if(distanceToWalkPoint.magnitude < 1f)
            {
                walkPointSet = false;
            }
        }

        private void SearchWalkPoint()
        {
            float x = Random.Range(-walkDistance, walkDistance);
            float z = Random.Range(-walkDistance, walkDistance);

            walkPoint = new Vector3(_transform.position.x + x,
                _transform.position.y, _transform.position.z + z);

            if (Physics.Raycast(walkPoint, -_transform.up, 2f, groundLayer))
                walkPointSet = true;

        }

        private void ChasePlayer()
        {
            agent.SetDestination(target.position);
        }

        private void AttackPlayer()
        {
            agent.SetDestination(_transform.position);

            _transform.LookAt(target.position);

            if (!hasAttacked)
            {
                RaycastHit hit;
                if (Physics.Raycast(shootPoint.transform.position,
                    shootPoint.transform.forward, out hit, 999f, playerLayer))
                {
                    Debug.Log(hit.transform.name);
                    hit.transform.GetComponent<PlayerHealth>().TakeDamage(attackDamage);
                }

                hasAttacked = true;
                Invoke(nameof(ResetAttack), timeBtwAttacks);
            }
        }

        private void ResetAttack()
        {
            hasAttacked = false;
        }

        private void OnDrawGizmos()
        {
            if (!showGizmos) return;

            Gizmos.color = Color.gray;
            Gizmos.DrawWireSphere(transform.position, walkDistance);
            Gizmos.color = Color.yellow;
            Gizmos.DrawWireSphere(transform.position, viewRange);
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, attackRange);
        }
    }
}