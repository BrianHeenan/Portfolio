using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickUp : MonoBehaviour
{
    

    void OnTriggerEnter(Collider other)
    {
        
        if (other.GetComponent<PlayerHealth>())
        {
            
            if (other.GetComponent<PlayerHealth>().currentHealth < other.GetComponent<PlayerHealth>().healthMax)
            {
                PlayerAttack playerAttack = FindObjectOfType<PlayerAttack>();
                playerAttack.healthParticle.Play();
                
                GetComponent<AudioSource>().Play();
                other.GetComponent<PlayerHealth>().currentHealth += 25;
                
                Destroy(this.gameObject);
            }
        }
    }
}
