using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompanionProgression : MonoBehaviour
{
    public static CompanionProgression Instance { get; private set; }

    public int SelectedCompanion;

    public bool HealthCollected, DamageCollected, SpeedCollected, DefenseCollected;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = null;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
}
