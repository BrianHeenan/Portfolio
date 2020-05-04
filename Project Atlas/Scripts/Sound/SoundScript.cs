using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundScript : MonoBehaviour
{
  
    public void playSound()
    {
        GetComponent<AudioSource>().Play();
    }
   
}
