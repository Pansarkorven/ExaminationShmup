using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class WaveManager : MonoBehaviour
{
    public GameObject[] enemyPrefabs; // The enemy prefab to spawn
    public Transform spawnPoint; // The point where enemies will spawn
    public float timeBetweenWaves = 10f; // Time between each wave
    public int numberOfWaves = 5; // Number of waves
    public string SceneToLoad;

    // Define an event to signal the completion of waves
    public event Action WavesCompleted;

    private void Start()
    {
        // Start spawning waves
        StartCoroutine(SpawnWaves());
        FindAnyObjectByType<SceneNavigator>().SaveLastScene();
    }

    IEnumerator SpawnWaves()
    {
        for (int wave = 1; wave <= numberOfWaves; wave++)
        {
            yield return new WaitForSeconds(timeBetweenWaves);
            yield return SpawnWave(wave); // Use 'yield return' to wait for SpawnWave coroutine
        }

        // All waves finished spawning, trigger the event
        OnWavesCompleted();
    }

    IEnumerator SpawnWave(int waveNumber)
    {
        Debug.Log("Wave " + waveNumber + " Incoming!");

        // Spawn a number of enemies in this wave
        for (int i = 0; i < waveNumber * 2; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(1f); // Delay between enemy spawns within a wave
        }
    }

    void SpawnEnemy()
    {
        int randomIndex = UnityEngine.Random.Range(0, enemyPrefabs.Length);
        // Randomly determine the Y position within a range
        float randomY = UnityEngine.Random.Range(spawnPoint.position.y - 2f, spawnPoint.position.y + 2f);

        // Instantiate enemy at a random Y position
        Vector3 spawnPosition = new Vector3(spawnPoint.position.x, randomY, spawnPoint.position.z);
        Instantiate(enemyPrefabs[randomIndex], spawnPosition, Quaternion.identity);
    }

    void OnWavesCompleted()
    {
        Debug.Log("All waves finished! Signaling completion...");

        // Trigger the event if there are subscribers
        SceneManager.LoadScene(SceneToLoad);
    }
}

