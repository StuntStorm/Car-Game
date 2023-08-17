using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleMovement : MonoBehaviour
{
    public float moveSpeed = 10f;
    public float rotationSpeed = 100f;

    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        // Get input for movement and rotation
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Calculate movement and rotation
        Vector3 movement = transform.forward * verticalInput * moveSpeed * Time.deltaTime;
        Quaternion rotation = Quaternion.Euler(0f, horizontalInput * rotationSpeed * Time.deltaTime, 0f);

        // Apply movement and rotation to the Rigidbody
        rb.MovePosition(rb.position + movement);
        rb.MoveRotation(rb.rotation * rotation);
    }
}
