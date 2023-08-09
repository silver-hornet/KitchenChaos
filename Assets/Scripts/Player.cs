using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float moveSpeed = 7f;
    [SerializeField] GameInput gameInput;
    bool isWalking;

    void Update()
    {
        Vector2 inputVector = gameInput.GetMovementVectorNormalized();

        Vector3 moveDir = new Vector3(inputVector.x, 0f, inputVector.y);

        float moveDistance = moveSpeed * Time.deltaTime;
        float playerRadius = 0.7f;
        float playerHeight = 2f;
        bool canMove = !Physics.CapsuleCast(transform.position, transform.position + Vector3.up * playerHeight, playerRadius, moveDir, moveDistance);
        // This will return true if the cast hits something, else false. In this case, we're using CapsuleCast instead of Raycast, since Raycast only shoots a thin laser
        // forward from the centre of the player. CapsuleCast gives us a ray that has shape so as to ensure collisions are properly detected on the player.

        // This code block is meant to solve diagonal movement so that when a player collides with an object and wants to move diagonally against it, the code
        // below automatically moves the player left, right, up, or down while trying to move diagonally against the object.
        if (!canMove)
        {
            // Cannot move towards moveDir

            // Attempt only X movement
            Vector3 moveDirX = new Vector3(moveDir.x, 0, 0).normalized; // Adding .normalized ensures that diagonal movement against an object isn't slower than just moving in one direction next to it
            canMove = !Physics.CapsuleCast(transform.position, transform.position + Vector3.up * playerHeight, playerRadius, moveDirX, moveDistance);

            if (canMove)
            {
                // Can move only on the X
                moveDir = moveDirX;
            }
            else
            {
                // Cannot move only on the X

                // Attempt only Z movement
                Vector3 moveDirZ = new Vector3(0, 0, moveDir.z).normalized; // Adding .normalized ensures that diagonal movement against an object isn't slower than just moving in one direction next to it
                canMove = !Physics.CapsuleCast(transform.position, transform.position + Vector3.up * playerHeight, playerRadius, moveDirZ, moveDistance);

                if (canMove)
                {
                    // Can move only on the Z
                    moveDir = moveDirZ;
                }
                else
                {
                    // Cannot move in any direction
                }
            }
        }

        if (canMove)
        {
            transform.position += moveDir * moveDistance;
        }

        isWalking = moveDir != Vector3.zero;
        float rotateSpeed = 10f;
        transform.forward = Vector3.Slerp(transform.forward, moveDir, Time.deltaTime * rotateSpeed); // Ensures the player rotates to face the correct direction. Slerp works better for rotations; Lerp works better for positions.
    }

    public bool IsWalking()
    {
        return isWalking;
    }
}
