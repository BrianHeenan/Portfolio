using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableLevelLightup : MonoBehaviour
{
    LevelProgression LP;

    //table Lights
    public GameObject gauntletLight;
    public GameObject castleLight;
    public GameObject hiveLight;
    public GameObject sewerLight;
    public GameObject cemetaryLight;
    public GameObject millLight;
    public GameObject bossLight;
    
    //portal particles
    public GameObject gauntletParticles;
    public GameObject castleParticles;
    public GameObject hiveParticles;
    public GameObject sewerParticles;
    public GameObject cemetaryParticles;
    public GameObject millParticles;
    public GameObject bossParticles;

    // Start is called before the first frame update
    void Start()
    {
        LP = FindObjectOfType<LevelProgression>();
    }

    // Update is called once per frame
    void Update()
    {
        if(LP.LevelUnlocked[0] == true)
        {
            gauntletLight.SetActive(true);
            gauntletParticles.SetActive(true);
        }
        if (LP.LevelUnlocked[1] == true)
        {
            castleLight.SetActive(true);
            castleParticles.SetActive(true);
        }
        if (LP.LevelUnlocked[2] == true)
        {
            hiveLight.SetActive(true);
            hiveParticles.SetActive(true);
        }
        if (LP.LevelUnlocked[3] == true)
        {
            sewerLight.SetActive(true);
            sewerParticles.SetActive(true);
        }
        if (LP.LevelUnlocked[4] == true)
        {
            cemetaryLight.SetActive(true);
            cemetaryParticles.SetActive(true);
        }
        if (LP.LevelUnlocked[5] == true)
        {
            millLight.SetActive(true);
            millParticles.SetActive(true);
        }
        if(LP.LevelUnlocked[6] == true)
        {
            bossLight.SetActive(true);
            bossParticles.SetActive(true);
        }
    }
}
