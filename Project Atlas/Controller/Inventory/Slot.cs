using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class Slot
{ 
    public ItemController item;
    public bool occupied; //
    public Rect position;  //where is slot in the frame

   


    public Slot(Rect position)
    {
        this.position = position;
    }
    public void Draw(float frameX, float frameY)
    {
        //  this gets position on inventory image
        if (item != null)
        {
            GUI.DrawTexture(new Rect(frameX + position.x, frameY + position.y, position.width, position.height), item.image);

        }
    }
}
