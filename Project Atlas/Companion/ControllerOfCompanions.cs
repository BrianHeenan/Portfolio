using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerOfCompanions : MonoBehaviour
{
    //[HideInInspector]
    public GameObject Player, PlayerBody, CompanionRespawnPoint, LevelProgression, HealthCompanion, DamageCompanion, SpeedCompanion, DefenseCompanion;

    //[HideInInspector]
    public int SelectedCompanion, BasePlayerHealth, BasePlayerDamage;

    //[HideInInspector]
    public float BasePlayerSpeed;

    [Tooltip("Amount you want to increase on the player")]
    public int HealthIncrease, DamageIncrease, SpeedIncrease;

    public bool RunMe;

    public void Start()
    {
        Player = GameObject.Find("/Player Character/PlayerCharacter_BaseRig");
        CompanionRespawnPoint = GameObject.Find("/Player Character/PlayerCharacter_BaseRig/CompanionRespawn");
        LevelProgression = GameObject.Find("/LevelProgression");
        HealthCompanion = GameObject.Find("/Companion_Pig");
        DamageCompanion = GameObject.Find("/Companion_Bee");
        SpeedCompanion = GameObject.Find("/Companion_Crow");
        DefenseCompanion = GameObject.Find("/Companion_Turtle");
        BasePlayerHealth = Player.GetComponent<PlayerHealth>().healthMax;
        BasePlayerDamage = Player.GetComponent<PlayerAttack>().attackDamage;
        BasePlayerSpeed = Player.GetComponent<PlayerMovement>().tempSpeed;
        SelectedCompanion = LevelProgression.GetComponent<CompanionProgression>().SelectedCompanion;
        CompanionSwitch();
    }

    public void Update()
    {
        SelectedCompanion = LevelProgression.GetComponent<CompanionProgression>().SelectedCompanion;
        if(RunMe == true)
        {
            CompanionSwitch();
        }
    }

    public void CompanionSwitch()
    {
        switch (SelectedCompanion)
        {
            case 1:
                HealthOn();
                DamageOff();
                SpeedOff();
                DefenseOff();
                CompanionActivation();
                RunMe = false;
                break;
            case 2:
                HealthOff();
                DamageOn();
                SpeedOff();
                DefenseOff();
                CompanionActivation();
                RunMe = false;
                break;
            case 3:
                HealthOff();
                DamageOff();
                SpeedOn();
                DefenseOff();
                CompanionActivation();
                RunMe = false;
                break;
            case 4:
                HealthOff();
                DamageOff();
                SpeedOff();
                DefenseOff();
                CompanionActivation();
                RunMe = false;
                break;
            default:
                CompanionActivation();
                RunMe = false;
                break;
        }
    }

    public void CompanionActivation()
    {
        switch (SelectedCompanion)
        {
            case 1:
                HealthCompanion.transform.position = CompanionRespawnPoint.transform.position;
                HealthCompanion.SetActive(true);
                DamageCompanion.SetActive(false);
                SpeedCompanion.SetActive(false);
                DefenseCompanion.SetActive(false);
                break;
            case 2:
                DamageCompanion.transform.position = CompanionRespawnPoint.transform.position;
                HealthCompanion.SetActive(false);
                DamageCompanion.SetActive(true);
                SpeedCompanion.SetActive(false);
                DefenseCompanion.SetActive(false);
                break;
            case 3:
                SpeedCompanion.transform.position = CompanionRespawnPoint.transform.position;
                HealthCompanion.SetActive(false);
                DamageCompanion.SetActive(false);
                SpeedCompanion.SetActive(true);
                DefenseCompanion.SetActive(false);
                break;
            case 4:
                DefenseCompanion.transform.position = CompanionRespawnPoint.transform.position;
                HealthCompanion.SetActive(false);
                DamageCompanion.SetActive(false);
                SpeedCompanion.SetActive(false);
                DefenseCompanion.SetActive(true);
                break;
            default:
                HealthCompanion.SetActive(false);
                DamageCompanion.SetActive(false);
                SpeedCompanion.SetActive(false);
                DefenseCompanion.SetActive(false);
                break;
        }
    }

    public void HealthOn()
    {
        if(Player.GetComponent<PlayerHealth>().healthMax == BasePlayerHealth)
        {
            Player.GetComponent<PlayerHealth>().healthMax += HealthIncrease;
            Player.GetComponent<PlayerHealth>().currentHealth += HealthIncrease;
        }
    }

    public void HealthOff()
    {
        Player.GetComponent<PlayerHealth>().healthMax = BasePlayerHealth;
        Player.GetComponent<PlayerHealth>().currentHealth = BasePlayerHealth;
    }

    public void DamageOn()
    {
        if(Player.GetComponent<PlayerAttack>().attackDamage == BasePlayerDamage)
        {
            Player.GetComponent<PlayerAttack>().attackDamage += DamageIncrease;
        }
    }

    public void DamageOff()
    {
        Player.GetComponent<PlayerAttack>().attackDamage = BasePlayerDamage;
    }

    public void SpeedOn()
    {
        if(Player.GetComponent<PlayerMovement>().speed == BasePlayerSpeed)
        {
            Player.GetComponent<PlayerMovement>().tempSpeed += SpeedIncrease;
        }
    }

    public void SpeedOff()
    {
        Player.GetComponent<PlayerMovement>().tempSpeed = BasePlayerSpeed;
    }

    public void DefenseOn()
    {
        Player.GetComponent<PlayerHealth>().defenseCompanion = true;
    }

    public void DefenseOff()
    {
        Player.GetComponent<PlayerHealth>().defenseCompanion = false;
    }
}
