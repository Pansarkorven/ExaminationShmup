using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletEnemy : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 10f;
    public int DamageAmount = 1;
    public float LifeTime = 5f;

    private GameManager gameManager;

    private void Start()
    {
        Destroy(gameObject, LifeTime);
    }

    void Update()
    {
        // Move the bullet forward
        transform.Translate(Vector2.left * speed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the bullet collided with an enemy
        if (other.CompareTag("Player"))
        {
            other.GetComponent<PlayerController>().TakeDamage(DamageAmount);

            Destroy(gameObject);


        }
    }
}


