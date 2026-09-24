using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    private PlayerController playerController;
    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private Transform firePoint;

    private void Awake()
    {
        playerController = GetComponent<PlayerController>();
    }

    void OnEnable()
    {
        playerController.OnAttackPressed += Attack;
    }
    void OnDisable()
    {
        playerController.OnAttackPressed -= Attack;
    }

    void Attack()
    {
        Instantiate( projectilePrefab, firePoint.position, firePoint.rotation );
    }
}

