using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class damageVolume : MonoBehaviour
{
    //this should be on a damage volume;
    public GameObject Player;
    // Start is called before the first frame update
    void Start()
    {
        Player = FindObjectOfType<PlayerHealth>().gameObject;
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == Player)
        {
            other.GetComponent<PlayerHealth>().TakeDamage(10);
        }
    }
}
