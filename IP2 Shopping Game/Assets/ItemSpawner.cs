using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    public ItemBaseBehaviour ItemPrefab;

    [SerializeField] private Transform[] ItemSpawns;

    // Start is called before the first frame update
    void Start()
    {
        SpawnItem();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnItem()
    {
        int i = Random.Range(0, ItemSpawns.Length);
        ItemBaseBehaviour ItemClone = Instantiate(ItemPrefab, ItemSpawns[i].position, ItemSpawns[i].rotation);
        if (gameObject.name == "Player 1 Item Spawner")
        {
            ItemClone.gameObject.tag = "Player 1";
        }
        else if (gameObject.name == "Player 2 Item Spawner")
        {
            ItemClone.gameObject.tag = "Player 2";
        }
    }
}
