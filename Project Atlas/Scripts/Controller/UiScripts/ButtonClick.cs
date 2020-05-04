using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonClick : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip audioClip;
    public AudioClip hoverFx;

    public void playClip()
    {
        audioSource.clip = audioClip;
        audioSource.Play();
    }

    public void HoverSound()
    {
        audioSource.PlayOneShot(hoverFx);
    }
}
