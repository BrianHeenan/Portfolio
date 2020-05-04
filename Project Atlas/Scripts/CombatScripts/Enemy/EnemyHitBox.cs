using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHitBox : MonoBehaviour
{
    EnemyAttack enemyAttack;
    public int damage = 10;

    private void Start()
    {
        enemyAttack = GetComponentInParent<EnemyAttack>();
    }

    private void Update()
    {
        damage = enemyAttack.damage; // makes the damage of hitbox the enemies damage
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PlayerHealth>()) // if hitting player
        {
            other.GetComponent<PlayerHealth>().TakeDamage(damage);
        }
    }
}
