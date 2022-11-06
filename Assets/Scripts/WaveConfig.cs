using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Enemy Wave Config")]
public class WaveConfig : ScriptableObject
{
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] GameObject pathPrefab;
    [SerializeField] float timeBetweenSpawns = 0.5f;
    [SerializeField] float spawnRandomFactor = 0.3f;
    [SerializeField] int numberOfEnemies = 5;
    [SerializeField] float moveSpeed = 2f;

    public GameObject GetEnemyPrefab() =>  enemyPrefab;

    public List<Transform> GetWaypoints() {
        var waveWaypoints = new List<Transform>();

        foreach(Transform waypoint in pathPrefab.transform){
            waveWaypoints.Add(waypoint);
        }
        return waveWaypoints;
    }

    public float GetTimeBetweenSpawns() =>  timeBetweenSpawns;
    public float GetSpawnRandomFactor() =>  spawnRandomFactor;
    public float GetMoveSpeed() => moveSpeed;

    public int GetNumberOfEnemies() => numberOfEnemies;


}
