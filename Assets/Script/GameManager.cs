using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum GameState
{
    menu,
    inGame,
    gameOver
}

public class GameManager : MonoBehaviour
{

    public GameState currentGameState = GameState.menu;

    private PlayerController controller;

    public static GameManager sharedInstance;
    // Start is called before the first frame update

    void Awake()
    {
        if (sharedInstance == null)
        {
            sharedInstance = this;
        }
    }

    void Start()
    {
        controller = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Submit") && currentGameState != GameState.inGame)
        {
            StartGame();
        }
        else if (Input.GetKeyDown(KeyCode.P))
        {
            BackToMenu();
        }
        else if (Input.GetKeyDown(KeyCode.Q))
        {
            GameOver();
        }
    }

    public void StartGame()
    {
        SetGameState(GameState.inGame);
    }

    public void GameOver()
    {
        SetGameState(GameState.gameOver);
    }

    public void BackToMenu()
    {
        SetGameState(GameState.menu);
    }

    private void SetGameState(GameState newGameState)
    {
        if (newGameState == GameState.menu)
        {
            //TODO: menu logic
        }
        else if (newGameState == GameState.inGame)
        {
            LevelManager.sharedInstance.RemoveAllLevelBlocks();
            ReloadLevel();
            //Invoke("ReloadLevel", 0.1f); 
        }
        else if (newGameState == GameState.gameOver)
        {
            //TODO: game over logic
        }

        this.currentGameState = newGameState;
    }

    void ReloadLevel()
    {
        LevelManager.sharedInstance.GenerateInitialBlocks();
        controller.StartGame();
    }
}