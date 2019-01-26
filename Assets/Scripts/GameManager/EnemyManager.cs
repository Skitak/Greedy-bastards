using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public float lowEnemySpawnDistance, mediumEnemySpawnDistance;
    public GameObject lowEnemyPrefab, mediumEnemyPrefab, highEnemyPrefab;
    public float lowSpawnRateA, lowSpawnRateB, highSpawnRateA, highSpawnRateB;
    public Timer spawnTimer;

    void Start() {
        
    }
    void OnDrawGizmosSelected()
    {
        // Draw a yellow sphere at the transform's position
        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(transform.position, searchRadius);
    }

    
}
