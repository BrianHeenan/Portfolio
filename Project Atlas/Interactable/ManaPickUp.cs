using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManaPickUp : MonoBehaviour
{

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

            {
                GetComponentInParent<AudioSource>().Play();
             //   other.GetComponent<PlayerHealth>().currentHealth += 10;
                gameObject.SetActive(false);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
