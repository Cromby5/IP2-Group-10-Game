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

    // Holders for items that get placed into the cart
    public Transform pos1;
    public Transform pos2;
    public Transform pos3;

    // Audio Sources + Clips
    public AudioSource audioSource;
    public AudioClip pickUpSound;
    public AudioClip checkOutSound;

    public LevelInitialize manager;


    private bool winState;
    // Start is called before the first frame update
    void Start()
    {
        itemsHeld = 0;
        totalItems = 0;
        winState = false;

        //player = gameObject.GetComponent<PlayerMove>();
        Bar.SetMaxItems(AmountOfItemsToGet);
        Bar.ShowProgress(totalItems);
    }

    // Update is called once per frame
    void Update()
    {
        if (totalItems >= AmountOfItemsToGet && !winState)
        {
            manager.StartCoroutine("EndGame");
            winState = true;
        }
    }

    public void ItemAdd()
    {
        audioSource.PlayOneShot(pickUpSound);
        itemsHeld += 1;
        playerText.text = "Items Held: " + itemsHeld + " / " + maxHeldItems;
        if (itemsHeld < maxHeldItems)
        {
            itemSpawn.SpawnItem();
        }
    }

    public void ItemRemove()
    {
        if (itemsHeld == 0)
            return;
        audioSource.PlayOneShot(checkOutSound);
        totalItems += itemsHeld;
        totalText.text = "Total Items: " + totalItems;
        Bar.ShowProgress(totalItems);
        if (itemsHeld >= 3)
        {
            itemSpawn.SpawnItem();
            //player.AddTrap();
        }
        itemsHeld = 0;

        foreach (Transform childTransform in pos1.transform) Destroy(childTransform.gameObject);
        foreach (Transform childTransform in pos2.transform) Destroy(childTransform.gameObject);
        foreach (Transform childTransform in pos3.transform) Destroy(childTransform.gameObject);

        playerText.text = "Items Held: " + itemsHeld + " / " + maxHeldItems;
    }

    public void PlayerHit()
    {
        if (itemsHeld > 0)
        {
            itemsHeld -= 1;
            playerText.text = "Items Held: " + itemsHeld + " / " + maxHeldItems;
            if (itemsHeld == 2)
            {
                itemSpawn.SpawnItem();
            }
        }
    }
}
