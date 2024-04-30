using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5.0f;
    public float jumpForce = 10.0f;
    public float gravity = 20.0f;
    public float sensitivity = 2.0f;

    private CharacterController characterController;
    private Camera playerCamera;
    private float verticalRotation = 0;
    private Vector3 velocity;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
        playerCamera = GetComponentInChildren<Camera>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        // Перемещение игрока
        float forwardInput = Input.GetAxis("Vertical") * speed;
        float sideInput = Input.GetAxis("Horizontal") * speed;

        Vector3 playerSpeed = new Vector3(sideInput, 0, forwardInput);
        playerSpeed = transform.rotation * playerSpeed;

        // Применение гравитации
        velocity.y -= gravity * Time.deltaTime;

        // Перемещение с учетом гравитации
        characterController.Move(playerSpeed * Time.deltaTime + velocity * Time.deltaTime);

        // Вращение камеры с помощью мыши
        float mouseX = Input.GetAxis("Mouse X") * sensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * sensitivity;

        verticalRotation -= mouseY;
        verticalRotation = Mathf.Clamp(verticalRotation, -90f, 90f);

        playerCamera.transform.localRotation = Quaternion.Euler(verticalRotation, 0, 0);
        transform.Rotate(Vector3.up * mouseX);

        // Прыжок
        if (Input.GetButtonDown("Jump") && characterController.isGrounded)
        {
            velocity.y = jumpForce;
        }
    }
}
