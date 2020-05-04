using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime : MonoBehaviour
{
    [Tooltip("Drag in the smaller version slime prefab if it is not filled")]
    public GameObject Smaller_Slime;

    public int SpawnNum;

    public void Split()
    {
        for (int i = 0; i < SpawnNum; i++)
        {
            Instantiate(Smaller_Slime, transform.position, transform.rotation);
        }
    }
}
