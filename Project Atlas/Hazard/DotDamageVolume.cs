using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DotDamageVolume : MonoBehaviour
{
    float timer = 1;

    void Update()
    {
        timer -= Time.deltaTime;
    }

    void OnTriggerStay(Collider other)
    {
        if (other.GetComponent<PlayerHealth>())
        {
            if(timer < 0)
            {
                other.GetComponent<PlayerHealth>().TakeDamage(1);
                timer = 1;
            }
        }
    }
}
