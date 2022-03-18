using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class LevelInitialize : MonoBehaviour
{
    [SerializeField]
    private Transform[] playerSpawns;
    [SerializeField]
    private GameObject PlayerPrefab;

    [SerializeField] private float maxTime;
    public TextMeshProUGUI Timer_Display;

    void Start()
    {
        var playerConfigs = PlayerConfigManager.Instance.GetPlayerConfigs().ToArray();
        for (int i =0; i <playerConfigs.Length; i++)
        {
            var player = Instantiate(PlayerPrefab, playerSpawns[i].position, playerSpawns[i].rotation, gameObject.transform);
            player.GetComponent<PlayerInputHandler>().InitializePlayer(playerConfigs[i]);
        }
    }

    void Update()
    {
        maxTime -= Time.deltaTime;
        DisplayTime(maxTime);
        if (maxTime <= 0)
        {
            EndGame();
        }
    }

    void DisplayTime(float timeToDisplay)
    {
        timeToDisplay += 1;
        //Allows for accurate display of minutes and seconds
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        //Format for the display of the time (00:00)
        Timer_Display.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    void EndGame()
    {
        SceneManager.LoadScene("Menu");
    }

}
