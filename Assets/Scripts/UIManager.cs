using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI healthText;
    public TextMeshProUGUI scoreText;

    private GameManager gameManager;
    public string sceneToLoad;
    private HardCoreMode hardCoreMode;
    public string mainmenu;

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

    public void OnButtonClick()
    {
        // ladda specifierad scene
        SceneManager.LoadScene(sceneToLoad);
        FindAnyObjectByType<HardCoreMode>().StartGame();
    }

    public void OnButtonClick1()
    {
        SceneManager.LoadScene(mainmenu);
    }

    public void LastSceneLoaded()
    {
        FindAnyObjectByType<SceneNavigator>().LoadLastScene();
    }

    public void QuitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
    }

}
