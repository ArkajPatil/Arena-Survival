using UnityEngine;

public class PlayerAiming : MonoBehaviour
{
    // variables
    private PlayerController playerController;
    private Camera mainCamera;

    private void Awake()
    {
        playerController = GetComponent<PlayerController>();

        mainCamera = Camera.main;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // Get mouse position on screen
        Vector2 mousePosition = playerController.AimInput;

        // Convert mouse position into a ray from the camera
        Ray ray = mainCamera.ScreenPointToRay(mousePosition);

        // Check if the ray hits something
        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            // Get the 3D point where the ray hit
            Vector3 targetPosition = hit.point;

            // Calculate direction from player to target
            Vector3 direction = targetPosition - transform.position;

            // Only rotate horizontally
            direction.y = 0.0f;

            // Make sure the direction is not nearly zero
            if (direction.sqrMagnitude > 0.001f)
            {
                // Rotate player to face the target
                transform.rotation = Quaternion.LookRotation(direction);
            }
        }
    }
}
