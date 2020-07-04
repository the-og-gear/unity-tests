using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharController : MonoBehaviour
{
    // Standard behaviour
    public bool isPaused;

    // Movement
    public float speed = 10.0f;
    public float rotationSpeed = 2.0f;
    public float slideFriction = 0.3f;
    private Vector3 moveVelocity = Vector3.zero;
    private Vector3 hitNormal;
    private bool isGrounded;

    // Head rotation
    public Transform head;
    private float maxHeadRotation = 80.0f;
    private float minHeadRotation = -80.0f;
    private float currentHeadRotation = 0;

    // Jumping
    private float yVelocity = 0;
    public float jumpSpeed = 15.0f;
    public float gravity = 30.0f;

    // Cacheing
    private CharacterController controller;

    void Start()
    {
        isPaused = false;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        if (!isPaused)
        {
            // Handle movement
            Vector3 velocity = moveVelocity + yVelocity * Vector3.up;
            if (!isGrounded)
            {
                velocity.x += (1f - hitNormal.y) * hitNormal.x * (1f -slideFriction);
                velocity.z += (1f - hitNormal.y) * hitNormal.z * (1f - slideFriction);
            }
            controller.Move(velocity * Time.deltaTime);
            isGrounded = (Vector3.Angle(Vector3.up, hitNormal) <= controller.slopeLimit);

            // Handle rotation
            Vector2 mouseInput = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
            transform.Rotate(Vector3.up, mouseInput.x * rotationSpeed);
            // Subsection: Head rotation
            currentHeadRotation = Mathf.Clamp(currentHeadRotation + mouseInput.y * rotationSpeed, minHeadRotation, maxHeadRotation);
            head.localRotation = Quaternion.identity;
            head.Rotate(Vector3.left, currentHeadRotation);

            // Handle jumping and movement while jumping
            yVelocity -= gravity * Time.deltaTime;
            if (controller.isGrounded)
            {
                yVelocity = 0;

                if (Input.GetButtonDown("Jump"))
                {
                    yVelocity = jumpSpeed;
                }

                moveVelocity = transform.TransformDirection(new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"))) * speed;
            }
        }

        // Handle unlocking the cursor + exiting the application
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!isPaused)
            {
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            } else
            {
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
            }
            isPaused = !isPaused;
        }
    }

    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        hitNormal = hit.normal;
    }
}
