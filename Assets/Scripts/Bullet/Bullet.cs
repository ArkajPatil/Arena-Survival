using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float speed = 50f;
    [SerializeField] private float bulletDestroyTime = 3.0f;
    private float arenaSize = 25.0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(BulletDestroyCoroutine());
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.forward * speed * Time.deltaTime;
        
        // destroying bullet if it goes out of arena
        if(transform.position.x > arenaSize || transform.position.x < -arenaSize || transform.position.z > arenaSize || transform.position.z < -arenaSize )
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        EnemyHealth enemyHealth =
            collision.gameObject.GetComponent<EnemyHealth>();

        if (enemyHealth != null)
        {
            enemyHealth.TakeDamage(50.0f);
        }

        Destroy(gameObject);
    }

    IEnumerator BulletDestroyCoroutine()
    {
        yield return new WaitForSeconds(bulletDestroyTime);
        Destroy(gameObject);
    }
}
