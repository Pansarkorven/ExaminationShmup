using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillPlane : MonoBehaviour
{
   
    public int DamageAmount = 1;
    private void OnTriggerEnter2D(Collider2D other)
    {
         if (other.CompareTag("Enemy"))
        {
            Destroy(other.gameObject);
            
            other.GetComponent<PlayerController>().TakeDamage(DamageAmount);
        }
    }
}
