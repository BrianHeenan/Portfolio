using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestructableWithHealth : MonoBehaviour
{
    public GameObject HealthObject; //this object is the empty GO being turned on
    public GameObject DestructableObject;//TombObject
    public GameObject Player;
    // Start is called before the first frame update
    void Start()
    {
        Player = FindObjectOfType<PlayerHealth>().gameObject;
    }
    void OnTriggerStay(Collider other)
    {
        if (other.gameObject == Player && Input.GetMouseButtonDown(0) )
        {
            DestructableObject.SetActive(false);
            playSound();
            HealthObject.SetActive(true);
            
        }
    }
    public void playSound()
    {
        GetComponent<AudioSource>().Play();
    }
}

