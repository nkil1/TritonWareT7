using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CastleScript : MonoBehaviour
{
    public int castleHealth;
    public int scoreReward;

    public GameObject[] enemyTypes;
    public Vector2 spawnTimeRange;

    // maybe have this start with a random amount of enemies, like 20 to 30
    // and then slowly spawn out those 20/30, and then finally it can be destroyed after
    // all those enemies are killed

    void Start()
    {
        StartCoroutine(spawnEnemy());
    }

    void Update()
    {
        
    }

    private IEnumerator spawnEnemy()
    {
        Instantiate(enemyTypes[Random.Range(0, enemyTypes.Length)], transform.position, Quaternion.identity);
        yield return new WaitForSeconds(Random.Range(spawnTimeRange.x, spawnTimeRange.y));

        StartCoroutine(spawnEnemy());
    }
}
