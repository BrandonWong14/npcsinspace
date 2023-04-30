using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class Grappling : MonoBehaviour
{
    // Start is called before the first frame update

    // www.answers.unity.com/questions/1385517/grappling-hook-3.html
    public InputActionReference hookReference = null;
    public Camera cam = null;
    public Transform cam2 = null;
    Rigidbody rb;
    //public InputDevice _rightController;
    //public InputDetive _leftController;

    RaycastHit grapplePoint;

    bool isGrappling = false;

    // keeps track of the length of your "rope"
    public float distance = 1000.0f;

    public float grappleSpeed = 5f;
    //public float MovementAcceleration = 0.0f;
    //public float MouseSensitivity = 0.0f;
    //public float TopSpeed = 0.0f;
    //public Transform PlayerCamera = null;
    //private float cameraPitch = 0.0f;

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
/*
    private void Alive() 
    {
        hookReference.action.performed += Update2; 


    }

    private void destruction()
    {
        hookReference.action.performed -= Update2; 
    }
    */
    void Update()
    {
        // UpdateMouseLook();
        //cam = Camera.current;
        // Input.mousePosition
        
        //List<InputDevice> m_device = new List<InputDevice>();
        //bool primaryButtonDown = false;
        //InputDevices.GetDeiveWithCharacteristics(InputDeviceCharacteristics.left, m_device);
        //if (m_device.Count == 1) {
            //m_device[0].TryGetFeatureValue(CommonUsages.primaryButton, out primaryButtonDown);
        //}
        // if (Input.GetButtonDown("Fire1") && Physics.Raycast(ray, out grapplePoint))
        //if (Physics.Raycast(ray, out grapplePoint))
        //if (primaryButtonDown && Physics.Raycast(ray, out grapplePoint))
        //hookReference
        //ray
        // cam2.position, cam2.forward,
        Ray ray = cam.ScreenPointToRay(cam2.forward);
        if ((hookReference.action.ReadValue<float>() != 0) && Physics.Raycast(ray, out grapplePoint)) 
        {
            Vector3 hookDirection = (grapplePoint.point - transform.position);
            rb.velocity = hookDirection.normalized * grappleSpeed;
        }
        if (hookReference.action.ReadValue<float>() == 0) {
            rb.velocity = new Vector3(0, 0, 0);
        }


        /*
        if ((hookReference.action.ReadValue<float>() != 0) && Physics.Raycast(ray, out grapplePoint))
        {
            Debug.Log(cam2.position);
            Debug.Log(cam2.forward);
            isGrappling = true;
            // Vector3 grappleDirection = (grapplePoint.point - transform.position);
            Vector3 grappleDirection = (grapplePoint.point - cam2.position);
            rb.velocity = grappleDirection.normalized * grappleSpeed;
        }
        // (Input.GetButtonUp("Fire1"))
        if (hookReference.action.ReadValue<float>() == 0)
        {
            isGrappling = false;
            rb.velocity = new Vector3(0, 0, 0);
        }
        */
        // isGrappling
        /*
        
        if (isGrappling == true)
        {
            transform.LookAt(grapplePoint.point);
            Vector3 grappleDirection = (grapplePoint.point - transform.position);

            if (distance < grappleDirection.magnitude)
            {
                float velocity = rb.velocity.magnitude;
                Vector3 newDirection = Vector3.ProjectOnPlane(rb.velocity, grappleDirection);
                rb.velocity = newDirection.normalized * velocity;

            } else
            {
                rb.AddForce(grappleDirection.normalized * grappleSpeed);

            }
            distance = grappleDirection.magnitude;

        } else
        {
            //transform.rotation = Quaternion.LookRotation(Vector3.forward, Vector3.up);
            rb.velocity = new Vector3(0, 0, 0);
        }
        */
    }
}
