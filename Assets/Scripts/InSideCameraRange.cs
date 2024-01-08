using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InSideCameraRange : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Camera mainCamera;

    void Update()
    {
        MovePlayer();
    }

    void MovePlayer()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(horizontalInput, verticalInput, 0f) * moveSpeed * Time.deltaTime;
        transform.Translate(movement);

        // Ensure the player stays within the camera's view
        Vector3 clampedPosition = mainCamera.WorldToViewportPoint(transform.position);
        clampedPosition.x = Mathf.Clamp01(clampedPosition.x);
        clampedPosition.y = Mathf.Clamp01(clampedPosition.y);

        transform.position = mainCamera.ViewportToWorldPoint(clampedPosition);
    }
}