using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporting : MonoBehaviour
{
    // Start is called before the first frame update

    /*[Header("References")]
    private PlayerMovementGrappling pm;
    public Transform cam;
    public Transform grunTip;
    public LayerMask whatIsGrappleble;

    [Header("Grappling")]
    public float maxGrappleDistance;
    public float grappleDelayTime;

    private Vector3 grapplePoint;

    [Header("Cooldown")]
    public float grapplingCd;
    private float grapplingCdTimer;

    [Header("Input")]
    */
    // www.answers.unity.com/questions/1385517/grappling-hook-3.html
    public Camera cam = null;
    Rigidbody rb;

    RaycastHit grapplePoint;

    bool isGrappling = false;

    // keeps track of the length of your "rope"
    float distance;

    public float grappleSpeed = 5f;
    public float MovementAcceleration = 0.0f;
    public float MouseSensitivity = 0.0f;
    public float TopSpeed = 0.0f;
    public Transform PlayerCamera = null;
    private float cameraPitch = 0.0f;

    void Start()
    {

        //cam = Camera.current;
        rb = GetComponent<Rigidbody>();

    }
    /*
    void UpdateMouseLook()
    {
        Vector2 MouseDelta = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
        transform.Rotate(Vector3.up * MouseDelta.x * MouseSensitivity);

        cameraPitch -= MouseDelta.y * MouseSensitivity;
        cameraPitch = Mathf.Clamp(cameraPitch, -90.0f, 90.0f);
        PlayerCamera.localEulerAngles = Vector3.right * cameraPitch;
    }
    */
    // Update is called once per frame
    void Update()
    {
        // UpdateMouseLook();
        //cam = Camera.current;
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        if (Input.GetButtonDown("Fire2") && Physics.Raycast(ray, out grapplePoint))
        {
            isGrappling = true;
            transform.position = grapplePoint.point;
            print(grapplePoint.point);

        }
        if (Input.GetButtonUp("Fire2"))
        {
            isGrappling = false;
            rb.velocity = new Vector3(0, 0, 0);
        }
    }
}
