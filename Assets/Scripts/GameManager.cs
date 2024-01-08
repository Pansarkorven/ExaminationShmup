using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private int playerHealth = 5;
    private int playerScore = 0;
    private bool WaveisDone = false;
  
    
    


    private void Start()
    {
        // Subscribe to the WavesCompleted event
        FindObjectOfType<WaveManager>().WavesCompleted += OnWavesCompleted;
        Debug.Log("HardcoreMode setting: " + PlayerPrefs.GetInt("HardcoreMode", 0));

        if (PlayerPrefs.GetInt("HardcoreMode", 0) == 1)
        {
            playerHealth = 1;
        }
        else
        {
            playerHealth = 5;
        }
    }
    public void PlayerTakeDamage(int damageAmount)
    {
        playerHealth -= damageAmount;
        Debug.Log("Player health: " + playerHealth);

        if (playerHealth <= 0)
        {
            // Call a method for player death or other game over logic
            if (PlayerPrefs.GetInt("HardcoreMode", 1) == 0)
            {
                SceneManager.LoadScene("DeathScene");
            }
            else
            {
                SceneManager.LoadScene("DeathSceneHard");
            }
        }
    }

    public void PlayerEarnPoints(int points)
    {
        playerScore += points;
        Debug.Log("Player score: " + playerScore);

    }

    void PlayerDied()
    {
        Debug.Log("Player has died!");
        if (PlayerPrefs.GetInt("HardcoreMode", 0) == 1)
        {
            SceneManager.LoadScene("DeathScene");
        }
        else
        {
            SceneManager.LoadScene("DeathSceneHard");
        }

    }

    public int GetPlayerHealth()
    {
        return playerHealth;
    }

    public int GetPlayerScore()
    {
        return playerScore;
    }

    private void OnWavesCompleted()
    {
        Debug.Log("Waves are completed! Do something here...");
        // Add your logic here to change a value or perform other actions
        WaveisDone = true;
    }

    public bool AreNoObjectsWithTagAlive(string tag)
    {
        GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag(tag);
        return objectsWithTag.Length == 0;
    }



    
}
