using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnController : MonoBehaviour
{
    public Vector2 minPositions;
    public Vector2 maxPositions;
    public GameObject enemyPrefab;
    public float spawnTime;
    
    void spawn()
    {
        float spawnPositionY = Random.Range(minPositions.y, maxPositions.y);
        float spawnPositionX = Random.Range(minPositions.x, maxPositions.x);

        Vector3 enemyPosition = new Vector3(spawnPositionX, spawnPositionY, 0.0f);

        GameObject enemy = Instantiate(enemyPrefab, enemyPosition, Quaternion.identity);

        Invoke("spawn", spawnTime);

    }

    public void initSpawn()
    {
        Invoke("spawn", spawnTime);
    }

    public void cancelSpawn()
    {
        CancelInvoke("spawn");
    }
}
