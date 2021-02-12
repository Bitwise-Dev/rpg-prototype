using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputManager : MonoBehaviour
{
    public bool DebugMode = false;
    public PlayerInput playerInput;

    void Start()
    {
        playerInput = new PlayerInput(DebugMode);
    }

    void Update()
    {
        HandleMovement();

        playerInput.UpdateTime();
    }

    private void HandleMovement()
    {
        if (Input.GetKeyDown(KeyCode.W)) playerInput.AddCurrentInput(KeyCode.W, UserInputStateType.DOWN);
        if (Input.GetKeyUp(KeyCode.W)) playerInput.UpdateInputState(KeyCode.W, UserInputStateType.UP);

        if (Input.GetKeyDown(KeyCode.A)) playerInput.AddCurrentInput(KeyCode.A, UserInputStateType.DOWN);
        if (Input.GetKeyUp(KeyCode.A)) playerInput.UpdateInputState(KeyCode.A, UserInputStateType.UP);

        if (Input.GetKeyDown(KeyCode.S)) playerInput.AddCurrentInput(KeyCode.S, UserInputStateType.DOWN);
        if (Input.GetKeyUp(KeyCode.S)) playerInput.UpdateInputState(KeyCode.S, UserInputStateType.UP);

        if (Input.GetKeyDown(KeyCode.D)) playerInput.AddCurrentInput(KeyCode.D, UserInputStateType.DOWN);
        if (Input.GetKeyUp(KeyCode.D)) playerInput.UpdateInputState(KeyCode.D, UserInputStateType.UP);
    }
}
