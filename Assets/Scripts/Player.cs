using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float moveSpeed = 7f;

    void Update()
    {
        Vector2 inputVector = new Vector2(0, 0);

        if (Input.GetKey(KeyCode.W))
        {
            inputVector.y = +1;
        }
        if (Input.GetKey(KeyCode.S))
        {
            inputVector.y = -1;
        }
        if (Input.GetKey(KeyCode.A))
        {
            inputVector.x = -1;
        }
        if (Input.GetKey(KeyCode.D))
        {
            inputVector.x = +1;
        }

        inputVector = inputVector.normalized; // Ensures that player does not move faster when travelling diagonally

        Vector3 moveDir = new Vector3(inputVector.x, 0f, inputVector.y);
        transform.position += moveDir * moveSpeed * Time.deltaTime;

        float rotateSpeed = 10f;
        transform.forward = Vector3.Slerp(transform.forward, moveDir, Time.deltaTime * rotateSpeed); // Ensures the player rotates to face the correct direction. Slerp works better for rotations; Lerp works better for positions.
    }
}
