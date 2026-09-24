using UnityEngine;
using System;
using System.Collections;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private Transform playerTransform;

    [SerializeField] private float spawnIntervalTime = 1.0f;
    [SerializeField] private float minimumDistanceBetnNewlySpawnedEnemyAndPlayer = 5.0f;
    [SerializeField] private float arenaSize = 24.0f;

    [SerializeField] private GameObject[] enemiesPrefabArray;

    private Coroutine spawnCoroutine;

    // for enemy count
    public static event Action OnEnemySpawned;

    private void Awake()
    {
        
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SpawnEnemyCoroutine(int num)
    {
        for(int i=1; i<=num; i++)
        {
            float x,z;
            Vector3 spawnPosition;
            do{
            x = UnityEngine.Random.Range(-arenaSize, arenaSize);
            z = UnityEngine.Random.Range(-arenaSize, arenaSize);
            spawnPosition = new Vector3(x, 1.0f, z);

            } while( ((spawnPosition-playerTransform.position).sqrMagnitude < minimumDistanceBetnNewlySpawnedEnemyAndPlayer * minimumDistanceBetnNewlySpawnedEnemyAndPlayer) );

            GameObject enemyPrefab = GetRandomEnemyPrefab();
            Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
            OnEnemySpawned?.Invoke();

            yield return new WaitForSeconds(spawnIntervalTime);
        }

        spawnCoroutine = null;
    }

    private GameObject GetRandomEnemyPrefab()
    {
        int randomIndex = UnityEngine.Random.Range(0,enemiesPrefabArray.Length);
        GameObject enemyPrefab = enemiesPrefabArray[randomIndex];
        return enemyPrefab;   
    }

    public void SpawnEnemy(int num)
    {
        spawnCoroutine = StartCoroutine(SpawnEnemyCoroutine(num));
    }

    public void StopSpawning()
    {
        if(spawnCoroutine != null)
        {
            StopCoroutine(spawnCoroutine);
            spawnCoroutine = null;
        }
    }
}
