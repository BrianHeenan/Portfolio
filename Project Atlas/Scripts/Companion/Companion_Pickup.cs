using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Companion_Pickup : MonoBehaviour
{
    //[HideInInspector]
    public GameObject LevelProgression;

    //[HideInInspector]
    public bool Health, Damage, Speed, Defense;

    [Tooltip("1 = Health, 2 = Damage, 3 = Speed, 4 = Defense")]
    public int Companion;

    void Start()
    {
        LevelProgression = GameObject.Find("LevelProgression");
    }

    public void Update()
    {
        switch (Companion)
        {
            default:
                Health = false;
                Damage = false;
                Speed = false;
                Defense = false;
                gameObject.GetComponent<Renderer>().material.color = Color.white;
                break;

            case 1:
                Health = true;
                Damage = false;
                Speed = false;
                Defense = false;
                gameObject.GetComponent<Renderer>().material.color = Color.gray;
                break;

            case 2:
                Health = false;
                Damage = true;
                Speed = false;
                Defense = false;
                gameObject.GetComponent<Renderer>().material.color = Color.red;
                break;
            case 3:
                Health = false;
                Damage = false;
                Speed = true;
                Defense = false;
                gameObject.GetComponent<Renderer>().material.color = Color.yellow;
                break;
            case 4:
                Health = false;
                Damage = false;
                Speed = false;
                Defense = true;
                gameObject.GetComponent<Renderer>().material.color = Color.green;
                break;
        }
    }


    public void OnTriggerEnter(Collider other)
    {
        if (other.GetComponentInChildren<PlayerHealth>())
        {
            if(Health == true)
            {
                LevelProgression.GetComponent<CompanionProgression>().HealthCollected = true;
            }
            else if (Damage == true)
            {
                LevelProgression.GetComponent<CompanionProgression>().DamageCollected = true;
            }
            else if (Speed == true)
            {
                LevelProgression.GetComponent<CompanionProgression>().SpeedCollected = true;
            }
            else if (Defense == true)
            {
                LevelProgression.GetComponent<CompanionProgression>().DefenseCollected = true;
            }
            else
            {
                return;
            }

            Destroy(this.gameObject);

        }
    }
}
