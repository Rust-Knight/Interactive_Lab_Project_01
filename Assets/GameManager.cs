using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public static GameManager gameManager { get; private set; }

    public UnitHealth _playerHealth = new UnitHealth(100, 100);

    bool gameIsOver = false;

    public float restartDelay = 0.5f;

    void Awake()
    {
        if (gameManager != null && gameManager != this)
        {
            Destroy(this);
        }

        else
        {
            gameManager = this;
        }
    }

    public void EndGame() // Will end game
    {
        if(gameIsOver == false)
        {
            gameIsOver = true;
            Debug.Log("Game Over");
            Invoke("RestartGame", restartDelay);
        }
        
    }

    void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);// get and load current scene;
    }



}
