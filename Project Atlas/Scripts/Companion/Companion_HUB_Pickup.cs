using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Companion_HUB_Pickup : MonoBehaviour
{
    //[HideInInspector]
    public GameObject LevelProgression, CompanionController;

    //[HideInInspector]
    public bool On;

    public int WhoIAm;

    public void Start()
    {
        gameObject.GetComponent<Renderer>().enabled = false;
        LevelProgression = GameObject.Find("/LevelProgression");
        CompanionController = GameObject.Find("/GameManager");
    }

    public void Update()
    {
        WhatAmI();
    }

    public void WhatAmI()
    {
        switch (WhoIAm)
        {
            case 1:
                Health();
                break;
            case 2:
                Damage();
                break;
            case 3:
                Speed();
                break;
            case 4:
                Defense();
                break;
            case 5:
                Nothing();
                break;
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (WhoIAm == 1 && On == true && other.GetComponent<PlayerHealth>())
        {
            LevelProgression.GetComponent<CompanionProgression>().SelectedCompanion = 1;
            CompanionController.GetComponent<ControllerOfCompanions>().RunMe = true;
        }
        else if (WhoIAm == 2 && On == true && other.GetComponent<PlayerHealth>())
        {
            LevelProgression.GetComponent<CompanionProgression>().SelectedCompanion = 2;
            CompanionController.GetComponent<ControllerOfCompanions>().RunMe = true;
        }
        else if (WhoIAm == 3 && On == true && other.GetComponent<PlayerHealth>())
        {
            LevelProgression.GetComponent<CompanionProgression>().SelectedCompanion = 3;
            CompanionController.GetComponent<ControllerOfCompanions>().RunMe = true;
        }
        else if (WhoIAm == 4 && On == true && other.GetComponent<PlayerHealth>())
        {
            LevelProgression.GetComponent<CompanionProgression>().SelectedCompanion = 4;
            CompanionController.GetComponent<ControllerOfCompanions>().RunMe = true;
        }
        else if (WhoIAm == 5 && On == true && other.GetComponent<PlayerHealth>())
        {
            LevelProgression.GetComponent<CompanionProgression>().SelectedCompanion = 5;
            CompanionController.GetComponent<ControllerOfCompanions>().RunMe = true;
        }
    }

    public void Health()
    {
        if(LevelProgression.GetComponent<CompanionProgression>().HealthCollected == true)
        {
            gameObject.GetComponent<Renderer>().enabled = true;
            gameObject.GetComponent<Renderer>().material.color = Color.gray;
            On = true;
        }
    }

    public void Damage()
    {
        if (LevelProgression.GetComponent<CompanionProgression>().DamageCollected == true)
        {
            gameObject.GetComponent<Renderer>().enabled = true;
            gameObject.GetComponent<Renderer>().material.color = Color.red;
            On = true;
        }
    }
    public void Speed()
    {
        if (LevelProgression.GetComponent<CompanionProgression>().SpeedCollected == true)
        {
            gameObject.GetComponent<Renderer>().enabled = true;
            gameObject.GetComponent<Renderer>().material.color = Color.yellow;
            On = true;
        }
    }
    public void Defense()
    {
        if (LevelProgression.GetComponent<CompanionProgression>().DefenseCollected == true)
        {
            gameObject.GetComponent<Renderer>().enabled = true;
            gameObject.GetComponent<Renderer>().material.color = Color.green;
            On = true;
        }
    }

    public void Nothing()
    {
        if(LevelProgression.GetComponent<CompanionProgression>().HealthCollected == true || 
           LevelProgression.GetComponent<CompanionProgression>().DamageCollected == true ||
           LevelProgression.GetComponent<CompanionProgression>().SpeedCollected == true  ||
           LevelProgression.GetComponent<CompanionProgression>().DefenseCollected == true)
        {
            gameObject.GetComponent<Renderer>().enabled = true;
            gameObject.GetComponent<Renderer>().material.color = Color.white;
            On = true;
        }
    }
}
