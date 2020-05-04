using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[System.Serializable]
public abstract class ItemController
{//other classes will inherit from this class but cannot creat from this class.

    public Texture2D image;
    public int x;
    public int y;
    public int width; //this item could take up multipule slots..
    public int height;

    public abstract void performAction(); //abstract has no definition for this method
   
    
}
