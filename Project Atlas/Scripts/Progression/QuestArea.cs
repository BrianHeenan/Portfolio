using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestArea : MonoBehaviour
{
    public string questTitle;
    public string questDescription;
    [Tooltip("Place an enemy here")]
    public GameObject questTarget;

    private QuestManager questManager;

    private void Awake()
    {
        questManager = FindObjectOfType<QuestManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        questManager.activeQuest = this;
    }

    private void Update()
    {
        if(questTarget == null)
        {
            gameObject.SetActive(false);
        }
    }
}
