using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    public static event System.Action<Vector2> OnPlayerMovement;
    public static event System.Action OnPlayerJump;
    public static event System.Action OnPlayerStop;
    public static event System.Action OnGamePause;

    [SerializeField] PlayerInput playerInput;

    private void Awake()
    {
        playerInput = GetComponent<PlayerInput>();
    }

    private void OnEnable()
    {
        playerInput.onActionTriggered += HandleInput;
    }

    private void OnDisable()
    {
        playerInput.onActionTriggered -= HandleInput;
    }

    void HandleInput(InputAction.CallbackContext context)
    {
        string action = context.action.name;

        switch (action)
        {
            case "Movement":
                Vector2 input = context.ReadValue<Vector2>();
                OnPlayerMovement?.Invoke(input);
                if(context.canceled)
                {
                    OnPlayerStop?.Invoke();
                }
                break;

            case "Jumping":
                if (context.started)
                {
                    OnPlayerJump?.Invoke();
                }
                break;

            case "Pausing":
                if (context.started)
                {
                    OnGamePause?.Invoke();
                }
                break;
        }
    }
}
