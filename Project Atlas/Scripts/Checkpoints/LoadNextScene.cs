using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadNextScene : MonoBehaviour
{
    public int SceneToLoad;
    GameObject player;
    LevelProgression LP;
    private void Start()
    {
        LP = FindObjectOfType<LevelProgression>();
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Entered Trigger");
        player = FindObjectOfType<PlayerHealth>().gameObject;

        if(other.gameObject == player && SceneToLoad == 1)
        {
            SceneManager.LoadScene(1);
        }

        else if(other.gameObject == player && LP.LevelUnlocked[SceneToLoad - 2])
        {
            SceneManager.LoadScene(SceneToLoad);
        }

    }
}
