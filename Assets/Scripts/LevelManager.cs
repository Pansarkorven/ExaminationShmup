using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    private GameManager gameManager;

    private bool IsWaveDone = false;

    private void Start()
    {
        // Assuming GameManager is attached to the same GameObject or is accessible some other way
        gameManager = GetComponent<GameManager>();
        FindObjectOfType<WaveManager>().WavesCompleted += OnWavesCompleted;
        // Check if there are no objects with the "Enemy" tag alive
        bool areNoEnemiesAlive = gameManager.AreNoObjectsWithTagAlive("Enemy");

        if (IsWaveDone)
        {
            // Execute this block of code when both conditions are true
            Debug.Log("u have won congrats");
        }

    }

    private void OnWavesCompleted()
    {
        IsWaveDone = true;
        Debug.Log("the wave is done ");
    }
}
