using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 10f;
    public int DamageAmount = 1;
    public int ScorePerEnemyKilled = 10;
    public float LifeTime = 10f;

    private GameManager gameManager;

    private void Start()
    {
        Destroy(gameObject, LifeTime);
    }

    void Update()
    {
        // Move the bullet forward
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the bullet collided with an enemy
        if (other.CompareTag("Enemy"))
        {
            // Destroy the enemy
            Destroy(other.gameObject);

            FindObjectOfType<GameManager>().PlayerEarnPoints(ScorePerEnemyKilled);

            // Destroy the bullet
            Destroy(gameObject);

          
        }
    }
}
