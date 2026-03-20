using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class WaveConfig
{
    public Transform enemyPrefab;
    public int numberOfEnemy = 5;
    public Vector3 formationOffset = new Vector3(0.8f, 0, 0);
    public FlyPath flyPath;
    public float speed = 3f;
    public float timeBetweenSpawn = 0.5f;
    public float timeToNextWave = 2f;
}

public class EnemySpawner : MonoBehaviour
{
    public List<WaveConfig> enemyWaves;

    private void Start()
    {
        StartCoroutine(SpawnAllWaves());
    }

    IEnumerator SpawnAllWaves()
    {
        foreach (WaveConfig wave in enemyWaves)
        {
            yield return StartCoroutine(SpawnWave(wave));
            yield return new WaitForSeconds(wave.timeToNextWave);
        }
    }

    IEnumerator SpawnWave(WaveConfig waveInfo)
    {
        for (int i = 0; i < waveInfo.numberOfEnemy; i++)
        {
            // ⭐ spawn theo index, KHÔNG cộng dồn
            Vector3 spawnPosition = waveInfo.flyPath[0] + i * waveInfo.formationOffset;

            Transform enemy = Instantiate(
                waveInfo.enemyPrefab,
                spawnPosition,
                Quaternion.identity
            );

            FlyPathAgent agent = enemy.GetComponent<FlyPathAgent>();
            if (agent != null)
            {
                agent.flyPath = waveInfo.flyPath;
                agent.flySpeed = waveInfo.speed;
            }

            yield return new WaitForSeconds(waveInfo.timeBetweenSpawn);
        }
    }
}