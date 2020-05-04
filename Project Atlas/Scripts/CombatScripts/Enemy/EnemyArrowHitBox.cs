using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyArrowHitBox : MonoBehaviour
{
    int damage = 10;

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PlayerHealth>()) // if hitting player
        {
            other.GetComponent<PlayerHealth>().TakeDamage(damage);
        }
    }
}
