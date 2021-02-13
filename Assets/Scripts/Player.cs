using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Character player;
    private PlayerInput _playerInput;
    public Camera playerCamera;
    public GameObject playerInputManagerGameObject;
    void Start()
    {
        if (playerCamera == null)
        {
            Debug.LogError("Player Camera Not Set");
        }
        if (playerInputManagerGameObject == null)
        {
            Debug.LogError("Player Input Manager Not Set");
        }

        player = new Character();
        _playerInput = playerInputManagerGameObject.GetComponent<PlayerInputManager>().playerInput;
    }

    void Update()
    {
        HandleUserInput();
    }

    private void HandleUserInput()
    {
        Vector3 moveDirection = Vector3.zero;

        //if (_playerInput.TryGetUserInput(KeyCode.W, out UserInput userInput))
        //{
        //    if (userInput.UserInputState == UserInputStateType.DOWN)
        //    {
        //        moveDirection += playerCamera.transform.forward;
        //    }
        //}

        if (Input.GetKey(KeyCode.W)) moveDirection += playerCamera.transform.forward;
        if (Input.GetKey(KeyCode.S)) moveDirection += -playerCamera.transform.forward;
        if (Input.GetKey(KeyCode.A)) moveDirection += -playerCamera.transform.right;
        if (Input.GetKey(KeyCode.D)) moveDirection += playerCamera.transform.right;

        moveDirection.y = 0f;
        transform.position += moveDirection * 100 * Time.deltaTime;

        //if (moveDirection != Vector3.zero)
        //{
        //    transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(moveDirection), 100 * Time.deltaTime);
        //}

        Debug.Log(moveDirection);
    }
}
