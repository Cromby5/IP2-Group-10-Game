using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInventory : MonoBehaviour
{
    public int itemsHeld;
    private int maxHeldItems = 3;
    public int TotalItems;

    public ItemSpawner ItemSpawn;
    public Text PlayerText;

    // Start is called before the first frame update
    void Start()
    {
        itemsHeld = 0;
        TotalItems = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (TotalItems == 3)
        {
            Debug.Log("WIN");
        }
    }

    public void ItemAdd()
    {
        itemsHeld += 1;
        if (itemsHeld < maxHeldItems)
        {
            ItemSpawn.SpawnItem();
        }
    }

    public void ItemRemove()
    {
        TotalItems += itemsHeld;
        if(itemsHeld >= 3)
        {
            ItemSpawn.SpawnItem();
        }
        itemsHeld = 0;
    }
}
