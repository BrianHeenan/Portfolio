using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnockBack : MonoBehaviour
{
    public float knockback;
    public float knocktime;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<EnemyHealth>())
        {
            Rigidbody enemy = other.GetComponent<Rigidbody>();
            if(enemy != null)
            {
                
                Vector3 difference = enemy.transform.position - transform.position;
                difference = difference.normalized * knockback;
                enemy.AddForce(difference, ForceMode.Impulse);
                StartCoroutine(KnockBackDuration(enemy));
            }
        }
    }

    private IEnumerator KnockBackDuration(Rigidbody enemy)
    {
        if(enemy != null)
        {
            yield return new WaitForSeconds(knocktime);
            enemy.velocity = Vector3.zero;
            
        }
    }
}
