using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelInitialize : MonoBehaviour
{
    [SerializeField]
    private Transform[] playerSpawns;
    [SerializeField]
    private GameObject PlayerPrefab;


    void Start()
    {
        var playerConfigs = PlayerConfigManager.Instance.GetPlayerConfigs().ToArray();
        for (int i =0; i <playerConfigs.Length; i++)
        {
            var player = Instantiate(PlayerPrefab, playerSpawns[i].position, playerSpawns[i].rotation, gameObject.transform);
            player.GetComponent<PlayerInputHandler>().InitializePlayer(playerConfigs[i]);
        }
    }

}
