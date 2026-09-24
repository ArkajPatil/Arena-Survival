using UnityEngine;
using System;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] private EnemyData enemyData;
    [SerializeField] private GameObject deathVFX;

    private enum EnemyState 
    { 
        Idle,
        Chase,
        Attack, 
        Dead 
    }
    private EnemyState currentState;
    private EnemyState prevState;

    // [SerializeField] private float detectionRange = 10f;
    // [SerializeField] private float attackRange = 1.5f;

    private GameObject playerGameObject;
    private Transform playerTransform;
    private EnemyMovement enemyMovement;
    private EnemyCombat enemyCombat;
    private EnemyHealth enemyHealth;

    void Awake()
    {
        playerGameObject = GameObject.FindGameObjectWithTag("Player");
        playerTransform = playerGameObject.transform;

        currentState = EnemyState.Idle;
        prevState = EnemyState.Idle;

        enemyMovement = GetComponent<EnemyMovement>();
        enemyCombat = GetComponent<EnemyCombat>();
        enemyHealth = GetComponent<EnemyHealth>();
    }

    private void OnEnable()
    {
        enemyHealth.OnEnemyDeath += SetEnemyDeadState;
    }

    private void OnDisable()
    {
        enemyHealth.OnEnemyDeath -= SetEnemyDeadState;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        enemyCombat.SetAttackTarget(playerGameObject);
    }

    void OnDestroy()
    {
  
    }

    // Update is called once per frame
    void Update()
    {
        float sqrDistance = (playerTransform.position - transform.position).sqrMagnitude;

        if (sqrDistance <= enemyData.attackRange * enemyData.attackRange)
        {
            currentState = EnemyState.Attack;
        }
        else if (sqrDistance <= enemyData.detectionRange * enemyData.detectionRange)
        {
            currentState = EnemyState.Chase;
        }
        else
        {
            currentState = EnemyState.Idle;
        }
        
        ChangeState();
    }

    void ChangeState()
    {
        // continue only if state has been actually changed
        if(currentState == prevState)
        {
            return;
        }

        prevState = currentState;

        switch(currentState)
        {
            case EnemyState.Idle:
                enemyMovement.SetChaseTarget(null);
                enemyCombat.SetAttackState(false);
                break;

            case EnemyState.Chase:
                enemyMovement.SetChaseTarget(playerTransform);
                enemyCombat.SetAttackState(false);
                break;

            case EnemyState.Attack:
                enemyMovement.SetChaseTarget(null);
                enemyCombat.SetAttackState(true);
                break;

            case EnemyState.Dead:
                enemyMovement.SetChaseTarget(null);
                enemyCombat.SetAttackState(false);
                Destroy(gameObject);
                break;

            default:
                break;
        }
    }

    private void SetEnemyDeadState()
    {
        currentState = EnemyState.Dead;

        Debug.Log("death state");

        Instantiate( deathVFX, transform.position, Quaternion.identity );

        ChangeState();
    }
}
