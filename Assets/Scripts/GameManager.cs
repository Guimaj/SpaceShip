using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager: MonoBehaviour
{
    public GameState gameState;
    public GameObject playButton;
    public GameObject enemySpawnner;
    public GameObject gameOverBG;
    public GameObject backGround;
    public GameObject ship;
    public GameObject score;

    public enum GameState
    {
        Init,
        Play,
        GameOver
    }

    // Start is called before the first frame update
    void Start()
    {
        this.gameState = GameState.Init;
    }

    void updateGameState()
    {
        if (this.gameState == GameState.Init)
        {
            playButton.SetActive(true);
            gameOverBG.SetActive(false);
        }
        if (this.gameState == GameState.Play)
        {
            this.score.GetComponent<GameScore>().Score = 0;
            playButton.SetActive(false);
            gameOverBG.SetActive(false);
            ship.GetComponent<ShipController>().Init();
            enemySpawnner.GetComponent<EnemySpawnController>().initSpawn();

        }
        if (this.gameState == GameState.GameOver)
        {   
            gameOverBG.SetActive(true);
            destroyAllAfterGameOver();
            enemySpawnner.GetComponent<EnemySpawnController>().cancelSpawn();

            Invoke("resetGame", 5f);
        }
    }

    public void setGameState(GameState gameState)
    {
        this.gameState = gameState;
        updateGameState();
    }

    public void startGame()
    {
        setGameState(GameState.Play);
    }

    void resetGame()
    {
        setGameState(GameState.Init); 
    }

    public GameState GetGameState()
    {
        return this.gameState;
    }

    private void destroyAllAfterGameOver()
    {
        foreach(GameObject obj in GameObject.FindGameObjectsWithTag("Enemy"))
        {
            Destroy(obj);
        }

        foreach (GameObject obj in GameObject.FindGameObjectsWithTag("EnemyLaser"))
        {
            Destroy(obj);
        }

        foreach (GameObject obj in GameObject.FindGameObjectsWithTag("ShipLaser"))
        {
            Destroy(obj);
        }
    }
}   
