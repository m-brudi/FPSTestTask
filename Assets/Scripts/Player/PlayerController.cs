using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] Camera cam;
    [SerializeField] LayerMask groundLayer;

    [Header("Variables")]
    [SerializeField] float moveSpeed;
    [SerializeField] float jumpForce;
    [SerializeField] float gravity;
    [SerializeField] float lookSensitivity;
    [SerializeField] float lookXLimit;

    CharacterController charController;
    Vector3 moveDirection = Vector3.zero;
    float rotationX = 0;
    bool isGrounded;
    bool canMove = true;

    private void Start() {
        charController = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update() {
        isGrounded = Physics.Raycast(transform.position + new Vector3(0, 0.1f, 0), Vector3.down, .2f, groundLayer);

        if (isGrounded && moveDirection.y < 0) moveDirection.y = 0f;
        
        Vector3 forward = transform.TransformDirection(Vector3.forward);
        Vector3 right = transform.TransformDirection(Vector3.right);
        float moveY = moveDirection.y;
        moveDirection = (forward * Input.GetAxis("Vertical")) + (right * Input.GetAxis("Horizontal"));

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded) {
            moveDirection.y = Mathf.Sqrt(jumpForce * -gravity);
        } else {
            moveDirection.y = moveY;
        }
        moveDirection.y += gravity * Time.deltaTime;
        if (canMove) charController.Move(moveSpeed * Time.deltaTime * moveDirection);

        Rotate();
    }

    void Rotate() {
        if (canMove) {
            rotationX += -Input.GetAxis("Mouse Y") * lookSensitivity;
            rotationX = Mathf.Clamp(rotationX, -lookXLimit, lookXLimit);
            cam.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
            transform.rotation *= Quaternion.Euler(0, Input.GetAxis("Mouse X") * lookSensitivity, 0);
        }
    }

}
