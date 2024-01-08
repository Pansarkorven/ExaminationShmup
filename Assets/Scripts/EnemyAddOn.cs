using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAddOn : MonoBehaviour
{
    public float moveSpeed = 1.0f;
    public int damagAmount = 1;
    public float shootInterval = 2.0f; // Time between shots
    public GameObject bulletPrefab;
    public Transform shootPoint;

    private float timeSinceLastShot;

    void Start()
    {
        timeSinceLastShot = 0f;
    }

    void Update()
    {
        MoveLeft();

        // Shoot at intervals
        timeSinceLastShot += Time.deltaTime;
        if (timeSinceLastShot >= shootInterval)
        {
            Shoot();
            timeSinceLastShot = 0f;
        }
    }

    void MoveLeft()
    {
        transform.Translate(Vector2.left * moveSpeed * Time.deltaTime);
    }

    void Shoot()
    {
        Instantiate(bulletPrefab, shootPoint.position, Quaternion.identity);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            //gör så att spelaren tar skada
            other.GetComponent<PlayerController>().TakeDamage(damagAmount);

            Destroy(gameObject);
        }
    }
}
