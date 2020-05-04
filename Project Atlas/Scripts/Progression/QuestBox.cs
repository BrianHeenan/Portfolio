using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestBox : MonoBehaviour
{
    private Text questTitle;
    private Text questDescription;

    private QuestManager questManager;

    private void Awake()
    {
        questTitle = transform.Find("Quest Title").GetComponent<Text>();
        questDescription = transform.Find("Quest Description").GetComponent<Text>();

        questManager = FindObjectOfType<QuestManager>();
    }

    private void Update()
    {
        questTitle.text = questManager.activeQuest.questTitle;
        questDescription.text = questManager.activeQuest.questDescription;
    }
}
