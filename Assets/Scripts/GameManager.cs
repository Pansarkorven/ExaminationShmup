using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private int playerHealth = 10;
    private int playerScore = 0;

    public void PlayerTakeDamage(int damageAmount)
    {
        playerHealth -= damageAmount;
        Debug.Log("Player health: " + playerHealth);

        if (playerHealth <= 0)
        {
            // Call a method for player death or other game over logic
            PlayerDied();
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
        // Implement game over logic, e.g., restart the level, show game over screen, etc.
    }

    public int GetPlayerHealth()
    {
        return playerHealth;
    }

    public int GetPlayerScore()
    {
        return playerScore;
    }
}
