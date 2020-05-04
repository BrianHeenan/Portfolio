using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlameVents : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        GetComponent<Animator>().SetTrigger("isActive");
    }

    void PlaySound()
    {
        GetComponent<AudioSource>().Play();
    }
}
