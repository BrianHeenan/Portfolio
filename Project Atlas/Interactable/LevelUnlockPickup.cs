using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelUnlockPickup : MonoBehaviour
{
    public int unlockLevel;
   
    private void OnCollisionEnter(Collision other)
    {
        GameObject player = FindObjectOfType<PlayerHealth>().gameObject;
        LevelProgression LP = FindObjectOfType<LevelProgression>();
        if (other.gameObject == player)
        {
            LP.LevelUnlocked[unlockLevel] = true;
            Destroy(this.gameObject);
        }
    }
}
