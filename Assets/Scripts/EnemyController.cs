using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

    public float EnemyMoveSpeed = 1.0f;
    public int damageAmount = 1;    
    // Start is called before the first frame update    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        moveleft();
    }

    void moveleft()
    { 
      transform.Translate(Vector2.left * EnemyMoveSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            //gör så att spelaren tar skada
            other.GetComponent<PlayerController>().TakeDamage(damageAmount);

            Destroy(gameObject);
        }
    }
}
