using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class King_Slime : MonoBehaviour
{

    public GameObject mediumSlime;

    public float mediumTimer;

    public int mediumTime, ListSize, Capacity;

    public List<GameObject> Enemies;

    // Update is called once per frame
    void Update()
    {
        ListCheck();

        if(ListSize < Capacity)
        {
            mediumTimer += Time.deltaTime;

            SpawnMedium();
        }

        Purging();
    }

    public void ListCheck()
    {
        ListSize = Enemies.Count;
    }

    private void SpawnMedium()
    {
        if(mediumTimer >= mediumTime)
        {
            GameObject MSlimeClone = Instantiate(mediumSlime, transform.position, transform.rotation);
            mediumTimer = 0;
            Enemies.Add(MSlimeClone);
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
