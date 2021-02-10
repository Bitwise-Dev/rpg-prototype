using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Character player;
    public Camera playerCamera;
    void Start()
    {
        player = new Character();
        if (playerCamera == null)
        {
            Debug.LogError("Player Camera Not Set");
        }
    }

    void Update()
    {
        HandleUserInput();
    }

    private void HandleUserInput()
    {
        Vector3 moveDirection = Vector3.zero;

        if (Input.GetKey(KeyCode.W)) moveDirection += playerCamera.transform.forward;
        if (Input.GetKey(KeyCode.S)) moveDirection += -playerCamera.transform.forward;
        if (Input.GetKey(KeyCode.A)) moveDirection += -playerCamera.transform.right;
        if (Input.GetKey(KeyCode.D)) moveDirection += playerCamera.transform.right;

        moveDirection.y = 0f;
        transform.position += moveDirection.normalized * 10 * Time.deltaTime;

        if (moveDirection != Vector3.zero)
        {
            transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(moveDirection), 10 * Time.deltaTime);
        }

        Debug.Log(moveDirection);
    }
}
