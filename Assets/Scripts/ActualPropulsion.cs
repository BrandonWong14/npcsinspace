using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActualPropulsion : MonoBehaviour
{
    public float MovementAcceleration = 0.0f;
    public float MouseSensitivity = 0.0f;
    public float TopSpeed = 0.0f;
    public Transform PlayerCamera = null;
    public GameObject LeftController = null;
    public GameObject RightController = null;

    private Rigidbody rb;
    private float movementX;
    private float movementY;
    private float movementZ;
    private float cameraPitch = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        LeftTransform = LeftController.GetComponent<Transform>();
        RightTransform = RightController.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
