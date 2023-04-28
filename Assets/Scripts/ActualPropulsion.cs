using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ActualPropulsion : MonoBehaviour
{
    public float MovementAcceleration = 0.0f;
    public float TopSpeed = 0.0f;
    public Transform LeftTransform = null;
    public Transform RightTransform = null;

    private Rigidbody rb;
    private Vector3 leftdirection;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnVRLeftPrimaryButton() {
        rb.AddForce((LeftTransform.forward * MovementAcceleration));
    }

    void OnVRRightPrimaryButton() {
        rb.AddForce((RightTransform.forward * MovementAcceleration));
    }
}
