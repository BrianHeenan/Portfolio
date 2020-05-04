using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
Created on 1/11/2019 by: Nicolas Tsuji



*/
public class Companion_Follower : MonoBehaviour
{
    [HideInInspector]
    public float Speed;

    [HideInInspector]
    public bool On, PlayerStupidAndDied, CloseEnough;

    [HideInInspector]
    public GameObject Player, RespawnPoint;

    [HideInInspector]
    public Transform PlayerTrans, MyTransform, RespawnTransform;

    [HideInInspector]
    public Vector3 PlayerVec, MyVector;

    [HideInInspector]
    public float PlayerDeathTimer, PlayerDistance;

    void Awake()
    {
        RespawnPoint = GameObject.Find("/Player Character/PlayerCharacter_BaseRig/CompanionRespawn");

        Player = GameObject.Find("/Player Character/PlayerCharacter_BaseRig");

        PlayerStupidAndDied = false;

        PlayerDeathTimer = 0;

        Speed = 5;
    }

    // Update is called once per frame
    void Update()
    {
        PlayerTrans = Player.GetComponent<Transform>();

        var PlayerVec = Player.GetComponent<Transform>().position;

        MyTransform = gameObject.GetComponent<Transform>();

        RespawnTransform = RespawnPoint.GetComponent<Transform>();

        PlayerDistance = Vector3.Distance(PlayerTrans.position, transform.position);

        if(PlayerDistance < 2.5)
        {
            CloseEnough = true;
        }
        else
        {
            CloseEnough = false;
        }

        PlayerVec.y += 2;

        

        // Checks if I am close enough
        if (CloseEnough == false)
        {
            transform.LookAt(PlayerVec);

            // Move me forward
            transform.position += transform.forward * Speed * Time.deltaTime;
        }

        // Check if player has died
        if(Player.GetComponent<PlayerHealth>().isDead == true)
        {
            // Set this bool active to start the respawn
            PlayerStupidAndDied = true;
        }

        // Checks if player death bool is true
        if(PlayerStupidAndDied == true)
        {
            // Starts respawn timer
            PlayerDeathTimer += Time.deltaTime;

            // Checks if the timer has respawned
            if (PlayerDeathTimer >= Player.GetComponent<PlayerHealth>().respawnSeconds)
            {
                // Move me to the companion respawn location on the player
                MyTransform.position = RespawnTransform.position;

                // Reset timer
                PlayerDeathTimer = 0;

                // Reset bool
                PlayerStupidAndDied = false;
            }
        }
    }
}
