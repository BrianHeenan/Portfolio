using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestEnemyDeath : MonoBehaviour
{
    public GameObject Quest;

    // Update is called once per frame
    void Update()
    {
        if(gameObject.GetComponent<EnemyHealth>().currentHealth <= 0)
        {
            Quest.SetActive(true);
        }
    }
}
