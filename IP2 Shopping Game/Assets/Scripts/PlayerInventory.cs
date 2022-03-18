using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerInventory : MonoBehaviour
{
    private int itemsHeld;
    private int maxHeldItems = 3;
    private int totalItems;
    [SerializeField] private int AmountOfItemsToGet;

    public ItemSpawner itemSpawn;
    private PlayerMove player;

    public TextMeshProUGUI playerText;
    public TextMeshProUGUI totalText;

    public BarFill Bar;

    // Start is called before the first frame update
    void Start()
    {
        itemsHeld = 0;
        totalItems = 0;
        //player = gameObject.GetComponent<PlayerMove>();
        Bar.SetMaxItems(AmountOfItemsToGet);
        Bar.ShowProgress(totalItems);
    }

    // Update is called once per frame
    void Update()
    {
        
        if (totalItems >= AmountOfItemsToGet)
        {
            Debug.Log("WIN");
            SceneManager.LoadScene("Menu");
        }
    }

    public void ItemAdd()
    {
        itemsHeld += 1;
        playerText.text = "Items Held: " + itemsHeld + " / " + maxHeldItems;
        if (itemsHeld < maxHeldItems)
        {
            itemSpawn.SpawnItem();
        }
    }

    public void ItemRemove()
    {
        totalItems += itemsHeld;
        totalText.text = "Total Items: " + totalItems;
        Bar.ShowProgress(totalItems);
        if (itemsHeld >= 3)
        {
            itemSpawn.SpawnItem();
            //player.AddTrap();
        }
        itemsHeld = 0;
        playerText.text = "Items Held: " + itemsHeld + " / " + maxHeldItems;
    }
}
