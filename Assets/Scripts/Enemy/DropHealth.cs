using UnityEngine;

public class DropHealth : MonoBehaviour
{
    [SerializeField] private GameObject healthPackPrefab;
    [SerializeField] private float probability = 0.3f;

    private EnemyHealth enemyHealth;

    private void Awake()
    {
        enemyHealth = GetComponent<EnemyHealth>();
    }

    private void OnEnable()
    {
        enemyHealth.OnEnemyDeath += DropHealthPack;
    }

    private void OnDisable()
    {
        enemyHealth.OnEnemyDeath -= DropHealthPack;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void DropHealthPack()
    {
        float num = Random.Range(0.0f, 1.0f);
        if(num <= probability)
        {
        Vector3 spawnPosition = transform.position;
        Instantiate(healthPackPrefab, spawnPosition, Quaternion.identity);
        }
    }
}
