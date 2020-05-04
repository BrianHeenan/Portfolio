/*
 * Created by: Hunter Duncan
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DebugManager : MonoBehaviour
{
    PlayerHealth playerHealth;
    EnemyHealth[] enemies;
    LevelProgression levelProgression;
    public InputField inputField;
    public GameObject debugPanel;
    bool visable = false;
    public Toggle[] toggles;

    private void Start()
    {
        debugPanel.SetActive(visable);

        playerHealth = FindObjectOfType<PlayerHealth>();
        enemies = FindObjectsOfType<EnemyHealth>();
        levelProgression = FindObjectOfType<LevelProgression>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.BackQuote))
        {
            visable = !visable;
            debugPanel.SetActive(visable);
        }
    }

    public void Immortality()
    {
        playerHealth.isImmortal = !playerHealth.isImmortal;
    }

    public void DamagePlayer()
    {
        int num = int.Parse(inputField.text);
        playerHealth.TakeDamage(num);
    }

    public void KillPlayer()
    {
        playerHealth.TakeDamage(playerHealth.currentHealth);
    }

    public void KillEnemies()
    {
        for (int i = 0; i < enemies.Length; i++)
        {
            enemies[i].TakeDamage(enemies[i].currentHealth);
        }
    }

    public void LevelUnlock(int level)
    {
        levelProgression.LevelUnlocked[level] = toggles[level].GetComponent<Toggle>().isOn;
    }

    public void RestartLevel()
    {
        Scene loadedLevel = SceneManager.GetActiveScene();
        SceneManager.LoadScene(loadedLevel.name);
    }
}
