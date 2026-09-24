using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // variables
    [SerializeField] private float moveSpeed = 5f;
    private PlayerController playerController;

    private Rigidbody rigidBody;
    private Vector2 movementInput;

    private void Awake()
    {
        rigidBody = GetComponent<Rigidbody>();
        playerController = GetComponent<PlayerController>();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {

    }

    // Update is called once per frame
    private void Update()
    {
        movementInput = playerController.MovementInput;
    }

    private void FixedUpdate()
    {
        Vector3 movement = new Vector3( movementInput.x , 0.0f, movementInput.y );

        rigidBody.MovePosition( rigidBody.position + movement * moveSpeed * Time.fixedDeltaTime );
    }
}
