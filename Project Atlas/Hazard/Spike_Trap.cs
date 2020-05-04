using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spike_Trap : MonoBehaviour
{
    [Tooltip("Drag in my own animator if not set")]
    public Animator spikeAnim;                  // Set spike child as animator

    [Tooltip("Drag in the player")]
    public PlayerHealth playerHealth;           // Set as the player

    [HideInInspector]
    public GameObject Player;

    [HideInInspector]
    public float damageTimer = 0;               // Timer for the damage

    [HideInInspector]
    public bool active = false;                 // Turns on and off the damage and timer

    [Tooltip("Can be adjusted to what you want")]
    public int damage;                     // Amount to damage the player

    public void Start()
    {
        Player = GameObject.Find("/Player Character/PlayerCharacter_BaseRig");

        playerHealth = Player.GetComponent<PlayerHealth>();
    }

    void Update()
    {
        if(active == true)
        {
            damageTimer += Time.deltaTime;      // If player enters, then turn on timer
        }

        if(active == true && damageTimer >= 1 && playerHealth.currentHealth >= 0)
        {
            playerHealth.TakeDamage(damage);    // Damage player every one second
            damageTimer = 0;                    // Reset timer
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<PlayerHealth>())
        {
            spikeAnim.SetBool("Activated", true);   // Turn on animator bool
            active = true;                          // Turn on damage
        }
        else
        {
            return;                                 // Don't do anything if it doesn't have player health
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<PlayerHealth>())
        {
            spikeAnim.SetBool("Activated", false);  // Turn off animator bool
            active = false;                         // Set damage to false
            damageTimer = 0;                        // Reset timer
        }
        else
        {
            return;                                 // Don't do anything if it doesn't have player health
        }
    }
}
