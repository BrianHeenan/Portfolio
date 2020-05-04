using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArenaSpawnEnemies : MonoBehaviour
{
    public GameObject RangedEnemy, MeleeEnemy, BigEnemy;

    public List<GameObject> Enemies;

    public int Capacity, ListSize, Round, RoundRanged, RoundMelee, RoundBig;

    public bool Debug;

    public void Start()
    {
        Round = 1;
    }

    void Update()
    {
        ListCheck();

        RoundRanged = Random.Range(0, 10);
        RoundBig = Random.Range(0, 10);
        RoundMelee = Random.Range(0, 5);

        if (Debug == true)
        {
            Debugging();
        }
        else if (Debug == false)
        {
            Rounds();
        }

        Purging();
    }

    public void ListCheck()
    {
        ListSize = Enemies.Count;
    }

    public void Debugging()  // Manual Spawning
    {
        if (ListSize < Capacity)
        {
            if (Input.GetKeyDown(KeyCode.Alpha0))
            {
                GameObject rangedclone = Instantiate(RangedEnemy, transform.position, transform.rotation);

                Enemies.Add(rangedclone);
            }
            else if (Input.GetKeyDown(KeyCode.Alpha9))
            {
                GameObject meleeclone = Instantiate(MeleeEnemy, transform.position, transform.rotation);

                Enemies.Add(meleeclone);
            }
            else if (Input.GetKeyDown(KeyCode.Alpha8))
            {
                GameObject bigclone = Instantiate(BigEnemy, transform.position, transform.rotation);

                Enemies.Add(bigclone);
            }
        }
    }

    public void Rounds()
    {
        if(Round == 1 && ListSize == 0)
        {
            for (int i = 0; i < RoundRanged; i++)
            {
                GameObject rangedclone = Instantiate(RangedEnemy, transform.position, transform.rotation);

                Enemies.Add(rangedclone);
            }

            for (int i = 0; i < RoundMelee; i++)
            {
                GameObject meleeclone = Instantiate(MeleeEnemy, transform.position, transform.rotation);

                Enemies.Add(meleeclone);
            }

            for (int i = 0; i < RoundBig; i++)
            {
                GameObject bigclone = Instantiate(BigEnemy, transform.position, transform.rotation);

                Enemies.Add(bigclone);
            }
        }
    }

    public void Purging()
    {
        foreach (GameObject item in Enemies)
        {
            if (item.GetComponent<EnemyHealth>().currentHealth <= 0)
            {
                Enemies.Remove(item);
            }
        }
    }
}
