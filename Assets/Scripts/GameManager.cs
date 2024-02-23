using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    bool gameHasEnded = false;
    public float restartDelay = 5f;
    public GameObject gameOverUI;

    public static GameManager Instance;

    private int remainingBricks;

    private void Awake()
    {
        // Singleton pattern to ensure only one GameManager exists
        if (Instance == null)
            Instance = this;
        else if (Instance != this)
            Destroy(gameObject);

        // Initialize the count of remaining bricks
        remainingBricks = GameObject.FindGameObjectsWithTag("Brick").Length;
    }

    public void BrickDestroyed()
    {
        remainingBricks--;

        if (remainingBricks <= 0)
        {
            // All bricks are destroyed, transition to the next level
            LoadNextLevel();
        }
    }

    private void LoadNextLevel()
    {
        // Load the next scene assuming you have multiple levels
        SceneManager.LoadScene("Level 02");
    }



    public void EndGame()
    {
        if (gameHasEnded == false)
        {
            gameHasEnded = true;
            Invoke("Restart", restartDelay);
            gameOverUI.SetActive(true);

        }
    }
}
