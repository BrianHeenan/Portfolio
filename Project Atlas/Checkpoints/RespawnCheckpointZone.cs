using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnCheckpointZone : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<PlayerHealth>())
        {
            other.GetComponent<PlayerHealth>().respawnPoint = transform; // set the respawn point of the player to this checkpoint.
        }
    }
}
