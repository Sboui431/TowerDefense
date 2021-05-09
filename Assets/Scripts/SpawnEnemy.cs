using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Wave
{
    public GameObject enemyPrefab;
    public float spawnInterval;
    public int maxEnemies;
}

public class SpawnEnemy : MonoBehaviour
{
    public GameObject[] waypoint;
    public Wave[] waves;
    public int timeBetweenWaves = 5;
    public GameObject winMessagePanel;
    private float lastSpawnTime;
    private float enemiesSpawned = 0;

    // Start is called before the first frame update
    void Start()
    {
        lastSpawnTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        int currentWave = GameManager.singleton.GetWave();

        if(currentWave < waves.Length)
        {
            float timeInterval = Time.time - lastSpawnTime;
            float spawnInterval = waves[currentWave].spawnInterval;
            if(((enemiesSpawned==0 && timeInterval > timeBetweenWaves) 
                || timeInterval > spawnInterval) 
                && enemiesSpawned < waves[currentWave].maxEnemies)
            {
                lastSpawnTime = Time.time;
                GameObject newEnemy = Instantiate(waves[currentWave].enemyPrefab);
                newEnemy.GetComponent<Enemy>().waypoints = waypoint;
                enemiesSpawned++;
            }

            if(enemiesSpawned==waves[currentWave].maxEnemies && GameObject.FindGameObjectsWithTag("Enemy") == null)
            {
                GameManager.singleton.SetWave(GameManager.singleton.GetWave() + 1);
                GameManager.singleton.SetCoins(Mathf.RoundToInt(GameManager.singleton.GetCoins() * 1.1f));
                enemiesSpawned = 0;
                lastSpawnTime = Time.time;
            }
        }
        else
        {
            Time.timeScale = 0.0f;
            GameManager.singleton.gameOver = true;
            winMessagePanel.SetActive(true);
        }
    }

}

