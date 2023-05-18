using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotorcycleController : MonoBehaviour
{
    // Inspector variables
    public float acceleration = 100f;
    public float maxSpeed = 30f;
    public float rotationSpeed = 100f;

    // Private variables
    private float currentSpeed = 0f;

    // Components
    private Rigidbody rigidBody;

    private void Awake()
    {
        // Get the required components
        rigidBody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        // Get input axes
        float rotation = Input.GetAxis("Horizontal");
        float throttle = Input.GetAxis("Vertical");

        // Calculate rotation amount based on input
        float rotationAmount = rotation * rotationSpeed * Time.deltaTime;

        // Apply rotation to the motorcycle
        Quaternion deltaRotation = Quaternion.Euler(Vector3.up * rotationAmount);
        rigidBody.MoveRotation(rigidBody.rotation * deltaRotation);

        // Calculate acceleration based on input
        float accelerationAmount = throttle * acceleration * Time.deltaTime;

        // Apply acceleration to the motorcycle's speed
        currentSpeed += accelerationAmount;

        // Clamp the speed to the maximum speed
        currentSpeed = Mathf.Clamp(currentSpeed, 0f, maxSpeed);

        // Apply the speed to the motorcycle's position
        Vector3 forwardMovement = transform.forward * currentSpeed * Time.deltaTime;
        rigidBody.MovePosition(rigidBody.position + forwardMovement);
    }
}
