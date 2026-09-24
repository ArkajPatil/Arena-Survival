using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private InputActions inputActions;

    public Vector2 MovementInput {get; private set;}

    public Vector2 AimInput{get; private set;}

    public event Action OnAttackPressed;

    private void Awake()
    {
        inputActions = new InputActions();
    }

    private void OnEnable()
    {
        inputActions.Player.Enable();
    }

    private void OnDisable()
    {
        inputActions.Player.Disable();
    }

    private void OnDestroy()
    {
        inputActions.Dispose();
    }

    private void Update()
    {
        MovementInput = inputActions.Player.Movement.ReadValue<Vector2>();
        AimInput = inputActions.Player.Aim.ReadValue<Vector2>();
    
        // if(inputActions.Player.Attack.WasPressedThisFrame())
        if(inputActions.Player.Attack.IsPressed())
        {
            OnAttackPressed?.Invoke();
        }
    }
}
