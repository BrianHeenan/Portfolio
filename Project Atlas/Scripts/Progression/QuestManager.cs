using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    [HideInInspector]
    public GameObject objectiveTarget;

    public QuestArea activeQuest;

    public QuestBox questBox;

    private void Start()
    {
        questBox = FindObjectOfType<QuestBox>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {
            if (questBox.enabled)
            {
                questBox.enabled = false;
            }
            else
            {
                questBox.enabled = true;
            }
        }

        if(activeQuest.questTarget == null)
        {
            objectiveTarget = activeQuest.gameObject;
        }
        else
        {
            objectiveTarget = activeQuest.questTarget;
        }
    }
}
