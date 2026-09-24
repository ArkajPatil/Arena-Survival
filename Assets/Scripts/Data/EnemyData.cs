using UnityEngine;

[CreateAssetMenu(fileName = "EnemyData", menuName = "Game/Enemy Data")]
public class EnemyData : ScriptableObject
{
    public float maxHealth;
    public float moveSpeed;
    public float damage;
    public float attackCooldownTime;
    public float detectionRange;
    public float attackRange;
}