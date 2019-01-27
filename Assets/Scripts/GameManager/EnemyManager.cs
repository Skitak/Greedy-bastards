using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public float lowEnemySpawnDistance, mediumEnemySpawnDistance;
    public GameObject lowEnemyPrefab, mediumEnemyPrefab, highEnemyPrefab;
    public float lowSpawnRateA, lowSpawnRateB, highSpawnRateA, highSpawnRateB;
    public float maxSpawnRateDistance;
    public Timer spawnTimer;
    public float maxSpawnDistanceFromGroup = 20f;
    public bool showLowDistance, showMediumDistance;
    ArrayList allEnemies = new ArrayList();

    void Start() {
        spawnTimer = new Timer(5f, SpawnEnemy);
    }
    void OnDrawGizmosSelected()
    {
        // Draw a yellow sphere at the transform's position
        Gizmos.color = Color.yellow;
        if (showLowDistance)
            Gizmos.DrawSphere(transform.position, lowEnemySpawnDistance);
        else if (showMediumDistance)
            Gizmos.DrawSphere(transform.position, mediumEnemySpawnDistance);

    }
    public void StartSpawning() {
        spawnTimer.EndTime = GetSpawnTime();
        spawnTimer.Play();
    }

    public void StopSpawning() {
        spawnTimer.Pause();
    }

    float GetSpawnTime() {
        float interpolation = getFurtherPlayerPositionFromCenter().magnitude / maxSpawnRateDistance;
        float lowBound = Mathf.Lerp(lowSpawnRateA, lowSpawnRateB, interpolation);
        float highBound = Mathf.Lerp(highSpawnRateA, highSpawnRateB, interpolation);
        return Random.Range(lowBound, highBound);
    }

    Vector3 getFurtherPlayerPositionFromCenter() {
        Vector3 furtherPlayer = Vector3.zero;
        for (int i = 0; i < GameManager.GetNumberOfPlayers(); ++i)
            if (furtherPlayer.magnitude < GameManager.instance.players[i].transform.position.magnitude)
                furtherPlayer = GameManager.instance.players[i].transform.position;
        return furtherPlayer;
    }
    void SpawnEnemy() {
        Vector3 spawnPosition = GameManager.GetCenterPointfromPlayers() + GetRandomDistance(maxSpawnDistanceFromGroup);
        if (spawnPosition.magnitude < lowEnemySpawnDistance)
            allEnemies.Add(Instantiate(lowEnemyPrefab, spawnPosition, Quaternion.identity) as GameObject);
        else if (spawnPosition.magnitude < mediumEnemySpawnDistance)
            allEnemies.Add(Instantiate(mediumEnemyPrefab, spawnPosition, Quaternion.identity) as GameObject);
        else
            allEnemies.Add(Instantiate(highEnemyPrefab, spawnPosition, Quaternion.identity) as GameObject);
        spawnTimer.EndTime = GetSpawnTime();
        spawnTimer.Play();
    }

    Vector3 GetRandomDistance(float maxDistance){
        return new Vector3(Random.Range(maxDistance, -maxDistance),1f, Random.Range(maxDistance, -maxDistance));
    }

    public void Reset() {
        foreach (GameObject enemy in allEnemies) {
            if (enemy != null)
                Destroy(enemy);
        }
    }
    
}
