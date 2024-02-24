using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] GameObject prefabToSpawn;
    [SerializeField] float startTime;
    [SerializeField] float repeatTime;
    float xBond;
    float yBond;
    [SerializeField] float minSpeedEnemy;
    [SerializeField] float maxSpeedEnemy;
    EnemyMove enemyMove;
    GameManager gameManager;
    
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnEnemy", startTime, repeatTime);
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    void SpawnEnemy()
    {
        if(!gameManager.isGameOver)
        {
            xBond = UnityEngine.Random.Range(-7.5f, 7.5f);
            yBond = UnityEngine.Random.Range(-3.8f, 3.8f);
            GameObject enemy = Instantiate(prefabToSpawn, new Vector2(xBond, yBond), quaternion.identity);
            enemyMove = enemy.GetComponent<EnemyMove>();
            enemyMove.speed = UnityEngine.Random.Range(minSpeedEnemy, maxSpeedEnemy);
        }

    }
}
