using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicalItems : MonoBehaviour
{
    public static Inventory inventory;
    public GameObject gui;
    public int ItemElement;
    public ItemController item;



    // Start is called before the first frame update
    
    private void OnMouseDown()
    {
        Debug.Log("Pick me Up");
        inventory = gui.GetComponent<Inventory>();//drag gui item onto the item ie chest piece 
        inventory.addItem(Items.GetArmor(ItemElement));
        Destroy(gameObject);//need a click range......
      

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
