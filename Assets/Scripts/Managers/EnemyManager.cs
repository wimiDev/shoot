using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public PlayerHealth playerHealth;
    public GameObject enemy;
    public float spawnTime = 3f;
    public Transform[] spawnPoints;
    public GameObject[] enemypool;
    public int enemyCount = 0;
    public int enemyInScene = 5;


    void Start ()
    {
        InvokeRepeating ("Spawn", spawnTime, spawnTime);
    }


    void Spawn ()
    {
        this.CreateEnemy();
    }

    void AddToEnemyPool(GameObject enemy)
    {
        enemypool[enemypool.Length] = enemy;
    }

    void CreateEnemy()
    {
        if (this.enemyInScene >= enemyCount) return;
        int spawnPointIndex = Random.Range (0, spawnPoints.Length);
        Instantiate (enemy, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
        enemyCount += 1;
    }
}
