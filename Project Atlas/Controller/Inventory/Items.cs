using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Items : MonoBehaviour
{
    public List<ItemController> armorInspector;
   private static List<ItemController> armor;

    public void Start()
    {
        armor = armorInspector;
    }
    public static Armor GetArmor(int id)
    {
        Armor armor = new Armor(); //duplicating armor
        armor.image = Items.armor[id].image;//setting attirbutes that are set in inspector
        armor.width = Items.armor[id].width;
        armor.height = Items.armor[id].height;
        return armor;
    }

}
