using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HardCoreMode : MonoBehaviour
{
    public Toggle hardcoreToggle;
    private static HardCoreMode instance;

    private void Start()
    {

    }

    public void StartGame()
    {
        // Save the hardcore mode setting
        PlayerPrefs.SetInt("HardcoreMode", hardcoreToggle.isOn ? 1 : 0);

    }

    void Awake()
    {
        // Ensure there is only one instance of this script
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

}

