using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum GameState {
    menu, 
    inGame,
    gameOver
}

public class GameManager : MonoBehaviour
{

    public GameState currentGameState = GameState.menu;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void StartGame(){

    }

    void BackToMenu() {

    }

    void GameOver() {

    }

    private void SetGameState(GameState newGameState) {
        if(newGameState == GameState.menu) {
            //TODO: menu logic
        } else if(newGameState == GameState.inGame) {
            //TODO: game logic
        } else if(newGameState == GameState.gameOver) {
            //TODO: game over logic
        }

        this.currentGameState = newGameState;
    }
}