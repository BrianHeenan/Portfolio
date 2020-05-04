using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorController : MonoBehaviour
{
    private SpriteRenderer rend;
    public Sprite NormalCursor;

    public GameObject trailEffect;


    private void Start()
    {
        Cursor.visible = false;
       
    }
    // Update is called once per frame
    void Update()
    {
        Vector2 currosPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = currosPos;

       
    }
}
