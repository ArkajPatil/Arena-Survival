using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private Transform target;
    private Rigidbody rigidBody;
    [SerializeField] private EnemyData enemyData;

    void Awake()
    {
        rigidBody = GetComponent<Rigidbody>();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        ChaseTarget();
    }

    public void SetChaseTarget(Transform target)
    {
        this.target = target;
    }

    private void ChaseTarget()
    {
        if(target == null)
        {
            return;
        }
        
        Vector3 direction = target.position - transform.position;
        direction.y = 0.0f;
        if(direction.sqrMagnitude < 0.001f)
        {
            return;
        }
        direction.Normalize();

        rigidBody.MovePosition(rigidBody.position + direction * enemyData.moveSpeed * Time.fixedDeltaTime);
    }
}
