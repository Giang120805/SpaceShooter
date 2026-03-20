using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class EnemyWave
{
    public Transform enemyPrefab;   // Prefab enemy
    public int numberOfEnemy;       // Số lượng spawn
    public Vector3 formationOffset; // khoảng cách giữa các enemy
    public FlyPath flyPath;         // đường bay
    public float speed;             // tốc độ bay
    public float nextWaveDelay;     // delay sang wave tiếp
}