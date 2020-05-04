/*
 * Name: Hunter Duncan
 * Name: Brian Heenan
 * Date: 01/10/19
 * Edited: 02/11/19
 * Purpose: Set enemyies active.
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTriggerVolume : MonoBehaviour
{
    public GameObject SpawnEvent; //this object is the empty GO being turned on
    public List<GameObject> enemies;
    public int listSize;
    [Tooltip("Should the player be able to active this spawn event? /n Check if player can activate spawn event")]
    public bool canPlayerActivate;
    public GameObject[] walls;

    private void Start()
    {
        foreach (Transform child in SpawnEvent.transform)
        {
            if (child.GetComponent<EnemyHealth>())
            {
                enemies.Add(child.gameObject);
            }
        }
    }

    private void Update()
    {
        listSize = enemies.Count;
        if(listSize <= 0)
        {
            foreach (GameObject wall in walls)
            {
                wall.SetActive(false);
            }
        }
        else
        {
            Purging();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (canPlayerActivate)
        {
            if (other.GetComponent<PlayerHealth>())
            {
                SpawnEvent.SetActive(true);
                foreach (GameObject wall in walls)
                {
                    wall.SetActive(true);
                }
            }
        }
        else if (other.GetComponent<EnemyHealth>())
        {
            SpawnEvent.SetActive(true);
        }
    }

    public void Purging()
    {
        for (int i = 0; i < enemies.Count; i++)
        {
            if (enemies[i].GetComponent<EnemyHealth>().currentHealth <= 0)
            {
                enemies.RemoveAt(i);
            }
        }
    }
}
