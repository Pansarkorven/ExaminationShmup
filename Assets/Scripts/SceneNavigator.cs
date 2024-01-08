using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneNavigator : MonoBehaviour
{
    public string lastScene;
    public static SceneNavigator Instance;
    void Start()
    {

        // Save the initial scene
       
    }

    public void LoadLastScene()
    {
        // Load the last saved scene
        SceneManager.LoadScene(lastScene);
    }

    public void SaveLastScene()
    {
        // Save the current scene name
        lastScene = SceneManager.GetActiveScene().name;
    }

    void OnEnable()
    {
        // Subscribe to the sceneLoaded event
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Save the current scene when a new scene is loaded
        //SaveLastScene();
    }

    void OnDisable()
    {
        // Unsubscribe from the sceneLoaded event to prevent memory leaks
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
    void Awake()
    {
        // Ensure there is only one instance of this script
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
