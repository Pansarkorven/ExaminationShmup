using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI healthText;
    public TextMeshProUGUI scoreText;

    private GameManager gameManager;

    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    void Update()
    {
        UpdateUI();
    }

    void UpdateUI()
    {
        if (healthText != null)
        {
            healthText.text = "Health: " + gameManager.GetPlayerHealth();
        }

        if (scoreText != null)
        {
            scoreText.text = "Score: " + gameManager.GetPlayerScore();
        }
    }
}
