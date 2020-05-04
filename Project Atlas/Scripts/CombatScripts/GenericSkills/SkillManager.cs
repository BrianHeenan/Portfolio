////////////////
//Created 1/12/19 By Lloyd Jarrell
//
//
// 
//
////////////////

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillManager : MonoBehaviour
{
    [Tooltip("Place Melee weapon under the player, here.")]
    public GameObject sword;
    [Tooltip("Place Ranged weapon under the player, here.")]
    public GameObject bow;
    

    [Tooltip("Place sword skill bar under the GameUI, here.")]
    public GameObject swordSkillBar;
    [Tooltip("Place bow skill bar under the GameUI, here.")]
    public GameObject bowSkillBar;
    
    public void Update()
    {
        
        if (sword.activeInHierarchy == true)
        {
            MeleeBarSlotChange();
        }
        else if (bow.activeInHierarchy == true)
        {
            RangeBarSlotChange();
        }
        
    }

    public void MeleeBarSlotChange()
    {
        swordSkillBar.SetActive(true);
        bowSkillBar.SetActive(false);
        
    }

    public void RangeBarSlotChange()
    {
        swordSkillBar.SetActive(false);
        bowSkillBar.SetActive(true);
        
    }
    
    public void MeleeBar()
    {
        sword.SetActive(true);
        bow.SetActive(false);
       
    }

    public void RangeBar()
    {
        sword.SetActive(false);
        bow.SetActive(true);
        
    }
}

