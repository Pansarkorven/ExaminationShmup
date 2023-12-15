using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour
{
    public GameObject BulletPreFab;
    public Transform firepoint;

    public float MoveSpeed = 2.0f; //�ndrar hastigheten p� charakt�ren
    public float BarrelRollSpeed = 360f; //�ndrar hastigheten p� min characht�rs barrelroll
    float Duration = 1.0f; // �ndra detta f�r att �ndra l�ngedn p� barrelrollen
    private Rigidbody2D rb;

    private GameManager gameManager;

    private bool isBarrelRolling = false;

    // Start is called before the first frame update
    void Start()
    {
        //h�mtar rigidbody componenten fr�n player charachter
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

        //h�mtar inputen fr�n spelaren
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        //calculerar r�resle direktionen
        Vector2 movment = new  Vector2(horizontalInput, verticalInput) * MoveSpeed;

        //l�get till hastigheten till characht�ren rigidbody
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
                //roterar player p� x axeln
                float rotationAmount = BarrelRollSpeed * Time.deltaTime;
                transform.Rotate(Vector3.right * movment);


                elapsed += Time.deltaTime;
                yield return null;


            }
            //g�r s� att min barrelroll altid slutar vid 0
            transform.rotation = Quaternion.identity;

            isBarrelRolling = false;
        }

        
    }
   
   


}

