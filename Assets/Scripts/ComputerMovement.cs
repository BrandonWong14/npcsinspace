using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ComputerMovement : MonoBehaviour
{
    public float MovementAcceleration = 0.0f;
    public float MouseSensitivity = 0.0f;
    public Transform PlayerCamera = null;

    private Rigidbody rb;
    private float movementX;
    private float movementY;
    private float movementZ;
    private float cameraPitch = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void OnMove(InputValue movementValue)
    {
        Vector3 movementVector = movementValue.Get<Vector3>();

        movementX = movementVector.x;
        movementY = movementVector.y;
        movementZ = movementVector.z;
    }

    void Update()
    {
        UpdateMouseLook();
        Vector3 movement = transform.right * movementX + transform.forward * movementZ + transform.up * movementY;
        rb.AddForce(movement * MovementAcceleration);
    }

    void UpdateMouseLook()
    {
        Vector2 MouseDelta = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
        transform.Rotate(Vector3.up * MouseDelta.x * MouseSensitivity);

        cameraPitch -= MouseDelta.y * MouseSensitivity;
        cameraPitch = Mathf.Clamp(cameraPitch, -90.0f, 90.0f);
        PlayerCamera.localEulerAngles = Vector3.right * cameraPitch;
    }
}
