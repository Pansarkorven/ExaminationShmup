using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathSceneManager : MonoBehaviour
{
    private string previousScene;

    void Start()
    {
        SavePreviousScene();
    }

    void Update()
    {
        // Check for TMP button click
        if (Input.GetButtonDown("Fire1")) // Change "Fire1" to your TMP button input
        {
            LoadPreviousScene();
        }
    }

    void SavePreviousScene()
    {
        previousScene = SceneManager.GetActiveScene().name;
    }

    void LoadPreviousScene()
    {
        SceneManager.LoadScene(previousScene);
    }
}