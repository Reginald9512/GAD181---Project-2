using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public Transform Player;
    public float enemySpeed = 3f;
    private int minDistance = 0;
    public Transform shootPoint;

    //attacking
    public float timeBetweenAttacks;
    private bool alreadyAttacked;
    public GameObject projectile;
    public float projectileSpeed;

    //attack range
    public float attackRange;
    public bool playerInAttackRange;

    private void Update()
    {
        transform.LookAt(Player);

        if (Vector3.Distance(transform.position, Player.position) >= minDistance)
        {
            transform.position += transform.forward * enemySpeed * Time.deltaTime;
        }

        if (!alreadyAttacked && Vector3.Distance(Player.position,transform.position) <= attackRange)
        {
            Rigidbody rb = Instantiate(projectile, shootPoint.position, Quaternion.identity).GetComponent<Rigidbody>();
            rb.AddForce(transform.forward * projectileSpeed, ForceMode.Impulse);

            alreadyAttacked = true;
            Invoke(nameof(ResetAttack), timeBetweenAttacks);
        }
    }
    private void ResetAttack()
    {
        alreadyAttacked = false;
    }
}
