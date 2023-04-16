using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ComputerMovement : MonoBehaviour
{
    public float MovementAcceleration = 0.0f;
    public float MouseSensitivity = 0.0f;
    public float TopSpeed = 0.0f;
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
        Vector3 movementForward = transform.forward * movementZ;
        Vector3 movementRight = transform.right * movementX;
        Vector3 movementUp = transform.up * movementY;

        float xVel = transform.InverseTransformDirection(rb.velocity).x;
        float yVel = transform.InverseTransformDirection(rb.velocity).y;
        float zVel = transform.InverseTransformDirection(rb.velocity).z;

        if (xVel < TopSpeed && movementX > 0) {
            rb.AddForce(movementRight * MovementAcceleration);
        } else if (xVel > (-1 * TopSpeed) && movementX < 0) {
            rb.AddForce(movementRight * MovementAcceleration);
        }
        if (zVel < TopSpeed && movementZ > 0) {
            rb.AddForce(movementForward * MovementAcceleration);
        } else if (zVel > (-1 * TopSpeed) && movementZ < 0){
            rb.AddForce(movementForward * MovementAcceleration);
        }
        if (yVel < TopSpeed && movementY > 0) {
            rb.AddForce(movementUp * MovementAcceleration);
        } else if (yVel > (-1 * TopSpeed) && movementY < 0){
            rb.AddForce(movementUp * MovementAcceleration);
        }
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
