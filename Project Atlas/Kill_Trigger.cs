using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kill_Trigger : MonoBehaviour
{
    public object killTrigger;
    public Collider playerCollider;

    private void Start()
    {
        
    }
    //get ref to player health
    //get ref to players collider
    //look for collider with player tag
    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<PlayerHealth>())
        {
            other.GetComponent<PlayerHealth>().TakeDamage(other.GetComponent<PlayerHealth>().currentHealth);
            Debug.Log("Hit Player");
        }
    }
}
