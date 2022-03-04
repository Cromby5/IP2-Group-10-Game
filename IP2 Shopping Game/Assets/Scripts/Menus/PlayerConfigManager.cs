using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerConfigManager : MonoBehaviour
{
    private List<PlayerConfig> playerConfigs;

    [SerializeField]
    private int MaxPlayers = 2;

    public static PlayerConfigManager Instance { get; private set; }
    private void Awake()
    {
        if (Instance != null)
        {
            Debug.Log("ANOTHER INSTANCE");
        }
        else
        {
            Instance = this;
            //DontDestroyOnLoad(Instance);
            playerConfigs = new List<PlayerConfig>();
        }
    }

    public List<PlayerConfig> GetPlayerConfigs()
    {
        return playerConfigs;
    }

    public void SetPlayerType(int index, Material colour)
    {
        playerConfigs[index].PlayerMat = colour;
    }

    public void ReadyPlayer(int index)
    {
        playerConfigs[index].isReady = true;
        if (playerConfigs.Count == MaxPlayers && playerConfigs.All(p => p.isReady == true))
        {
            SceneManager.LoadScene("SampleScene");
        }
    }

    public void PlayerJoin(PlayerInput pi)
    {
        Debug.Log("Player join" + pi.playerIndex);
        pi.transform.SetParent(transform);

        if(!playerConfigs.Any(p => p.PlayerIndex == pi.playerIndex))
        {
            playerConfigs.Add(new PlayerConfig(pi));
        }
    }
}

public class PlayerConfig
{
    public PlayerConfig(PlayerInput pi)
    {
        PlayerIndex = pi.playerIndex;
        Input = pi;
    }
    public PlayerInput Input { get; set; }
    public int PlayerIndex { get; set; }
    public bool isReady { get; set; }
    public Material PlayerMat { get; set; }

}