using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    public ItemBaseBehaviour ItemPrefab;

    private int lastSpawn;

    [SerializeField] private Transform[] ItemSpawns; // List of spawn points

    void Start()
    {
        SpawnItem();
    }

    public void SpawnItem()
    {
        int i = Random.Range(0, ItemSpawns.Length); // Random number from 0 to how many items are in list of spawns

        if (i != lastSpawn)
        {
            ItemBaseBehaviour ItemClone = Instantiate(ItemPrefab, ItemSpawns[i].position, ItemSpawns[i].rotation); // Create a new item at the location our number points to in the array
            // If this is the player 1 item spawner the item is tagged for player 1
            if (gameObject.name == "Player 1 Item Spawner")
            {
                ItemClone.gameObject.tag = "Player 1";
            }
            // If this is the player 2 item spawner the item is tagged for player 2
            else if (gameObject.name == "Player 2 Item Spawner")
            {
                ItemClone.gameObject.tag = "Player 2";
            }
            lastSpawn = i; // Remember the last spawn location
        }
        // Run this method again to get a new spawn location
        else
        {
            SpawnItem(); 
        }
    }
}
