using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour
{
    public GameObject BulletPreFab;
    public Transform firepoint;

    public float MoveSpeed = 2.0f; //ändrar hastigheten på charaktären
    public float BarrelRollSpeed = 360f; //ändrar hastigheten på min charachtärs barrelroll
    float Duration = 1.0f; // ändra detta för att ändra längedn på barrelrollen
    private Rigidbody2D rb;

    private GameManager gameManager;

    private bool isBarrelRolling = false;

    // Start is called before the first frame update
    void Start()
    {
        //hämtar rigidbody componenten från player charachter
       rb = GetComponent<Rigidbody2D>();
       gameManager = FindObjectOfType<GameManager>();

    }

    public void TakeDamage(int damageAmount)
    {
        gameManager.PlayerTakeDamage(damageAmount);
    }

    public void PlayerEarnPoints(int points)
    {
        gameManager.PlayerEarnPoints(points);
    }

    void Shoot()
    {
        GameObject bullet = Instantiate(BulletPreFab, firepoint.position, firepoint.rotation);
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }

        //hämtar inputen från spelaren
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        //calculerar röresle direktionen
        Vector2 movment = new  Vector2(horizontalInput, verticalInput) * MoveSpeed;

        //läget till hastigheten till charachtären rigidbody
        rb.velocity = movment;

        if (Input.GetKeyDown(KeyCode.Space) && !isBarrelRolling)
        {
            isBarrelRolling=true;
            StartCoroutine(BarrelRoll());

        }
    
        
        IEnumerator BarrelRoll()
        {
       
            float elapsed = 0f;

            while (elapsed < Duration)
            {
                //roterar player på x axeln
                float rotationAmount = BarrelRollSpeed * Time.deltaTime;
                transform.Rotate(Vector3.right * movment);


                elapsed += Time.deltaTime;
                yield return null;


            }
            //gör så att min barrelroll altid slutar vid 0
            transform.rotation = Quaternion.identity;

            isBarrelRolling = false;
        }

        
    }
   
   


}

