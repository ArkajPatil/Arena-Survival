using UnityEngine;
using System.Collections;

public class WaveManager : MonoBehaviour
{
    [SerializeField] private EnemySpawner enemySpawner; 
    [SerializeField] private GameUI gameUI;
    
    private int spawnedEnemyCount = 0;
    private int killedEnemyCount = 0;

    private int currentWave = 0;
    private bool bWavesStopped = false;
    private Coroutine waveCoroutine;

    private void OnEnable()
    {
        EnemySpawner.OnEnemySpawned += EnemySpawned;
        EnemyHealth.OnEnemyDeathStaticEvent += EnemyKilled;
        EnemyHealth.OnEnemyDeathStaticEvent += ManageWaves;
    }
    private void OnDisable()
    {
        EnemySpawner.OnEnemySpawned -= EnemySpawned;
        EnemyHealth.OnEnemyDeathStaticEvent -= EnemyKilled;
        EnemyHealth.OnEnemyDeathStaticEvent -= ManageWaves;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        waveCoroutine = StartCoroutine(StartNewWave());
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    private void ManageWaves()
    {
        if(bWavesStopped)
        {
            return;
        }

        if(spawnedEnemyCount==currentWave*5 && killedEnemyCount==currentWave*5)
        {
            StartCoroutine(StartNewWave());
        }
    }

    IEnumerator StartNewWave()
    {
        gameUI.ShowWavePanel(currentWave);

        yield return new WaitForSeconds(2.0f);

        if(bWavesStopped)
        {
            yield break;
        }

        gameUI.DisableWavePanel();
        
        currentWave++;
        spawnedEnemyCount = 0;
        killedEnemyCount = 0;

        enemySpawner.SpawnEnemy(currentWave*5);
    }

    private void EnemySpawned()
    {
        spawnedEnemyCount++;
        Debug.Log("Enemy Spawned: " + spawnedEnemyCount);
    }
    private void EnemyKilled()
    {
        killedEnemyCount++;
        Debug.Log("Enemy Killed: " + killedEnemyCount);
    }

    public void StopWaves()
    {
        bWavesStopped = true;

        if(waveCoroutine != null)
        {
            StopCoroutine(waveCoroutine);
            waveCoroutine = null;
        }

        enemySpawner.StopSpawning();
    }
}
