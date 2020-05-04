using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public Texture2D image; //inventory ui image, may change to game object
    public Rect position; //this is position of ui inventory image

    public List<ItemController> items = new List<ItemController>();
    int slotWidthSize = 10; //this is HorizontalWrapMode many slotswide
    int slotHeightSize = 4; // this is how many slots wide
    public Slot[,] slots;//numbers hardcoded for array testing

    public int slotX;
    public int slotY;

    public int width = 29;//width of 1 inventory slot
    public int height = 30;//height of 1 inventory slot

    private ItemController tempItem;
    private Vector2 Selected;//clicked item
    private Vector2 PostSelection;//released mouse button
    private bool test;
    public GameObject InventoryUI;
    //private bool InvIsActive;   //commented out until the inventory is up and running, then uncomment.

    // Start is called before the first frame update
    void Start()
    {
        setSlots();
        test = false;
        //InvIsActive = false;   //commented out until the inventory is up and running, then uncomment.
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            gameObject.SetActive(InventoryUI);
        }
        else if (Input.GetKeyDown(KeyCode.I))
        {
            gameObject.SetActive(InventoryUI);
        }
        {
            if (test)
            {
                Test();
            }
        }
        void Test()
        {
            //addItem(0, 0, Items.GetArmor(0));//test
            test = true;
        }
    }
        void setSlots()
        {
            slots = new Slot[slotWidthSize, slotHeightSize];

            for (int x = 0; x < slotWidthSize; x++)
            {
                for (int y = 0; y < slotHeightSize; y++)
                {
                    slots[x, y] = new Slot(new Rect(slotX + width * x, slotY + height * y, width, height)); // this creates a 2d arrary for slots               
                }
            }
        }
    
        void drawTempItem()
        {
            if (tempItem != null)
            {
                GUI.DrawTexture(new Rect(Input.mousePosition.x, Screen.height - Input.mousePosition.y, tempItem.width * width, tempItem.height * height), tempItem.image);
            }
        }
        void OnGUI()
        {
            drawInventory();
            drawSlots();
            drawItems();
            detectGuiAction();
            drawTempItem();
        }
        public bool addItem(ItemController item)
        {
            for (int x = 0; x < slotWidthSize; x++)
            {
                for (int y = 0; y < slotHeightSize; y++)
                {
                    if (addItem(x, y, item))
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        bool addItem(int x, int y, ItemController item) //sx=slot X[]
        {

            for (int sX = 0; sX < item.width; sX++)
            {
                for (int sY = 0; sY < item.height; sY++)
                {
                    if (slots[x, y].occupied)
                    {

                        Debug.Log("Slot Occupied");
                        return false;
                    }
                }
            }
            if (x + item.width > slotWidthSize)
            {
                Debug.Log("Out of X range!!");
                return false;
            }

            else if
          (y + item.height > slotHeightSize)
            {
                Debug.Log("Out of Y range!!");
                return false;
            }
            Debug.Log("additem complete");

            item.x = x;
            item.y = y;
            items.Add(item);


            for (int sX = x; sX < item.width + x; sX++)
            {
                for (int sY = y; sY < item.height + y; sY++)
                {

                    slots[sX, sY].occupied = true;


                }
            }
            return true;
        }

        void removeItem(ItemController item)
        {
            for (int x = item.x; x < item.x + item.width; x++)
            {
                for (int y = item.y; y < item.y + item.height; y++)
                {
                    slots[x, y].occupied = false;
                }
            }
            items.Remove(item);
        }
        void detectGuiAction()
        {

            if (Input.mousePosition.x > position.x && Input.mousePosition.x < position.x + position.width)
            {
                if (Screen.height - Input.mousePosition.y > position.y && Screen.height - Input.mousePosition.y < position.y + position.height)
                {
                    detectMouse();
                }
            }
        }

        void detectMouse()
        {
            for (int x = 0; x < slotWidthSize; x++)
            {
                for (int y = 0; y < slotHeightSize; y++)
                {
                    Rect slot = new Rect(position.x + slots[x, y].position.x, position.y + slots[x, y].position.y, width, height);
                    if (slot.Contains(new Vector2(Input.mousePosition.x, Screen.height - Input.mousePosition.y)))
                    {
                        if (Event.current.isMouse && Input.GetMouseButtonDown(0))
                        {
                            Selected.x = x;
                            Selected.y = y;

                            for (int index = 0; index < items.Count; index++)
                            {
                                for (int countX = items[index].x; countX < items[index].x + items[index].width; countX++)
                                {
                                    for (int countY = items[index].y; countY < items[index].y + items[index].height; countY++)
                                    {
                                        if (countX == x && countY == y)
                                        {
                                            tempItem = items[index];
                                            removeItem(tempItem);
                                            return;
                                        }
                                    }
                                }
                            }
                            //  slots[x, y].item = null;                       
                        }
                        else if (Event.current.isMouse && Input.GetMouseButtonUp(0))
                        {
                            PostSelection.x = x;
                            PostSelection.y = y;
                            if (PostSelection.x != Selected.x || PostSelection.y != Selected.y)
                            {
                                if (tempItem != null)
                                {

                                    if (addItem((int)PostSelection.x, (int)PostSelection.y, tempItem))
                                    {
                                        //do nothing its sucessful
                                    }
                                    else
                                    {//return to previous loction on fail
                                        addItem(tempItem.x, tempItem.y, tempItem);
                                    }
                                    tempItem = null;
                                }
                            }
                            else
                            {
                                addItem(tempItem.x, tempItem.y, tempItem);
                                tempItem = null;
                            }
                        }
                        return;
                    }
                }
            }
        }


        void drawItems()
        {
            for (int count = 0; count < items.Count; count++)
            {
                GUI.DrawTexture(new Rect(4 + slotX + position.x + items[count].x * width, 4 + slotY + position.y + items[count].y * height, items[count].width * width - 8, items[count].height * height - 8), items[count].image);
            }
        }

        void drawInventory()
        {
            position.x = Screen.width - position.width; // minus makes sure it fits on the screen
            position.y = Screen.height - position.height - Screen.height * 0.2f;
            GUI.DrawTexture(position, image);
        }
        void drawSlots()
        {
            for (int x = 0; x < slotWidthSize; x++)
            {
                for (int y = 0; y < slotHeightSize; y++)
                {
                    slots[x, y].Draw(position.x, position.y);
                }
            }
        }

 }
