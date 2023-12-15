using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillPlane : MonoBehaviour
{
    public int DamageAmount = 1;
    private GameManager gameManager;

    void Start()
    {
        // Find the GameManager in the scene
        gameManager = FindObjectOfType<GameManager>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            // Destroy the enemy
            Destroy(other.gameObject);

            // Remove health from the GameManager
            gameManager.PlayerTakeDamage(DamageAmount);
        }
    }
}
