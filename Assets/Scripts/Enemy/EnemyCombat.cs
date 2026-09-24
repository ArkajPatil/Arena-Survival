using UnityEngine;
using System.Collections;

public class EnemyCombat : MonoBehaviour
{
    [SerializeField] private EnemyData enemyData;

    private bool bCoolDowned = true;
    private bool bAttackState = false;

    private IDamageable playerDamageable;
    
    void Awake()
    {
        
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(bAttackState && bCoolDowned)
        {
            StartCoroutine(AttackPlayer());
        }
    }

    IEnumerator AttackPlayer()
    {
        if(playerDamageable == null)
        {
            yield break;
        }

        // attack logic
        playerDamageable.TakeDamage(enemyData.damage);

        bCoolDowned = false;

        yield return new WaitForSeconds(enemyData.attackCooldownTime);

        bCoolDowned = true;
    }

    public void SetAttackState(bool bAttackState)
    {
        this.bAttackState = bAttackState;
    }

    public void SetAttackTarget(GameObject playerGameObject)
    {
        playerDamageable = playerGameObject.GetComponent<IDamageable>();
    }
}

