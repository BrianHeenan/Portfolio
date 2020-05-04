/*
 * Created by: Leslie Gunsolus
 * Start Date: 1/11/19
 * 
 * Contributions: Hunter Duncan-1/24/19
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponSwap : MonoBehaviour
{
    public float switchDelay = .5f;
    public GameObject WeaponIconUI_Melee;
    public GameObject WeaponIconUI_Range;
    public GameObject meleeWeapon;
    public GameObject rangeWeapon;

    PlayerAttack playerAttack;
    
    List<GameObject> weapons = new List<GameObject>();
    int selectedWeapon = 0;

    private void Start()
    {
        playerAttack = FindObjectOfType<PlayerAttack>();

        weapons.Add(meleeWeapon);         //Set the first weapon in the array as melee weapon.
        weapons.Add(rangeWeapon);         //Set the second weapon in the array as range weapon.

        SelectWeapon();
    }

    private void Update()
    {
        int previousSelectedWeapon = selectedWeapon;

        if (Input.GetKeyDown(KeyCode.LeftShift) && !playerAttack.isAttacking)
        {
            if(selectedWeapon > weapons.Count - 2)
            {
                selectedWeapon = 0;
            }
            else
            {
                selectedWeapon++;
            }
        }

        if(previousSelectedWeapon != selectedWeapon)
        {
            SelectWeapon();
        }
    }

    void SelectWeapon()
    {
        int i = 0;
        foreach (GameObject weapon in weapons)
        {
            if (i == selectedWeapon)
                weapon.SetActive(true);
            else
                weapon.SetActive(false);
            i++;
        }

        if (meleeWeapon.activeInHierarchy == true)
        {
            WeaponIconUI_Melee.SetActive(true);
            WeaponIconUI_Range.SetActive(false);
        }
        else if (rangeWeapon.activeInHierarchy == true)
        {
            WeaponIconUI_Melee.SetActive(false);
            WeaponIconUI_Range.SetActive(true);
        }
    }
}
