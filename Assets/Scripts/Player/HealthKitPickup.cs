using UnityEngine;

public class HealthKitPickup : MonoBehaviour
{
    [SerializeField] private float healAmount = 25.0f;

    private void OnTriggerEnter(Collider other)
    {
        PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();

        if (playerHealth == null)
        {
            return;
        }

        playerHealth.Heal(healAmount);

        Destroy(gameObject);
    }
}