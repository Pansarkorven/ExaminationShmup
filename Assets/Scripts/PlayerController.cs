using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour
{
    
    public float MoveSpeed = 2.0f; //ändrar hastigheten på charaktären
    public float BarrelRollSpeed = 360f; //ändrar hastigheten på min charachtärs barrelroll
    float Duration = 1.0f; // ändra detta för att ändra längedn på barrelrollen
    public float MaxHealth = 100f;
    private float currentHealth;
    public float StartScore = 0;
    private float currentScore;
    private Rigidbody2D rb;

    public TextMeshProUGUI healthtext; // refererar till charachtärens hp för textmesh pro
    public TextMeshProUGUI ScoreText;

    private bool isBarrelRolling = false;

    // Start is called before the first frame update
    void Start()
    {
        //hämtar rigidbody componenten från player charachter
       rb = GetComponent<Rigidbody2D>();
        currentHealth = MaxHealth; // sätter hp till sin max vid startet av varje runda
        currentScore = StartScore;
        UpdateHealthText();
        UpdateScoreText();
    }


    void UpdateHealthText()
    {
        if (healthtext != null)
        {   
            healthtext.text = "health:" + currentHealth.ToString();

            Debug.Log("health has changed");
        }
    }

    void UpdateScoreText()
    {
        if (ScoreText != null)
        {
            ScoreText.text = "Score:" + currentScore.ToString();

            Debug.Log("Score has changed");
        }
            
    }
    // Update is called once per frame
    void Update()
    {
        if (currentHealth <= 0)
        {
            //ska lägga till så att man åket till en restart screen typ
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
   
    public void TakeDamage(int damagAmount)
    {
        currentHealth -= damagAmount;

        UpdateHealthText();

        if (currentHealth <= 0) 
        {
            die();  
        }
    }
    void die()
    {
        Debug.Log("player has died!");
    }


}

