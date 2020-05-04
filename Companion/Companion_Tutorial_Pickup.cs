using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Companion_Tutorial_Pickup : MonoBehaviour
{
    public bool CompanionOn;

    //[HideInInspector]
    public GameObject TutCom, RespawnPoint;

    private void Awake()
    {
        TutCom = GameObject.Find("/TutorialCompanion");
        RespawnPoint = GameObject.Find("/Player Character/PlayerCharacter_BaseRig/CompanionRespawn");
        WhoAmI();
    }

    public void Start()
    {
        TutCom.SetActive(false);
    }

    public void WhoAmI()
    {
        switch (CompanionOn)
        {
            case true:
                gameObject.GetComponent<Renderer>().material.color = Color.cyan;
                break;
            case false:
                gameObject.GetComponent<Renderer>().material.color = Color.white;
                break;
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        switch (CompanionOn)
        {
            case true:
                TutCom.transform.position = RespawnPoint.transform.position;
                TutCom.SetActive(true);
                break;
            case false:
                TutCom.SetActive(false);
                break;
        }
    }
}
