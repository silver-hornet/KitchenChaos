using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInput : MonoBehaviour
{
    public static GameInput Instance { get; private set; }

    public event EventHandler OnInteractAction;
    public event EventHandler OnInteractAlternateAction;
    public event EventHandler OnPauseAction;

    PlayerInputActions playerInputActions;

    void Awake()
    {
        Instance = this;

        playerInputActions = new PlayerInputActions();
        // Usually, all game objects are automatically destroyed when a scene changes, except for the PlayerInputActions object.
        // This can sometimes cause a MissingReferenceException error. As a result, some logic from the previous game might affect the logic of the next game.
        // So we'll use an OnDestroy function to destroy this instance of the game object and unsubscribe from all the events.

        playerInputActions.Player.Enable();

        playerInputActions.Player.Interact.performed += Interact_performed;
        playerInputActions.Player.InteractAlternate.performed += InteractAlternate_performed;
        playerInputActions.Player.Pause.performed += Pause_performed;
    }

    void OnDestroy()
    {
        playerInputActions.Player.Interact.performed -= Interact_performed;
        playerInputActions.Player.InteractAlternate.performed -= InteractAlternate_performed;
        playerInputActions.Player.Pause.performed -= Pause_performed;

        playerInputActions.Dispose(); // This frees up the object and any associated memory it was taking

    }

    void Pause_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        OnPauseAction?.Invoke(this, EventArgs.Empty);
    }

    void InteractAlternate_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        OnInteractAlternateAction?.Invoke(this, EventArgs.Empty);
    }

    void Interact_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        OnInteractAction?.Invoke(this, EventArgs.Empty); // The ? is a Null Conditional Operator; a shortcut for doing an if statement null check. If not null, it will fire everything after the ?.
        // The null check ensures we don't get an error if there are no subscribers to this event.
    }

    public Vector2 GetMovementVectorNormalized()
    {
        Vector2 inputVector = playerInputActions.Player.Move.ReadValue<Vector2>();
        inputVector = inputVector.normalized; // Ensures that player does not move faster when travelling diagonally
        return inputVector;
    }
}
