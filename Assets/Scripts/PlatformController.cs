using UnityEngine;

public class PlatformController : MonoBehaviour
{
    public float rotationSpeed = 5f;
    public float returnSpeed = 2f;
    public GameObject sphere;

    private Quaternion initialRotation;

    void Start()
    {
        initialRotation = transform.rotation;
    }

    void Update()
    {
        // Check if running on a mobile device
        if (Application.isMobilePlatform)
        {
            // Use gyroscope input for rotation
            Vector3 tilt = Input.gyro.gravity.normalized;
            tilt = Quaternion.Euler(90, 0, 0) * tilt; // Adjust rotation to match device orientation
            tilt.z = 0; // Limit rotation to the x-y plane
            Vector3 rotation = tilt * rotationSpeed * Time.deltaTime;
            transform.Rotate(rotation);
        }
        else
        {
            // Use keyboard input for rotation
            float horizontalInput = Input.GetAxis("Horizontal");
            float verticalInput = Input.GetAxis("Vertical");
            Vector3 rotation = new Vector3(verticalInput, 0f, -horizontalInput) * rotationSpeed * Time.deltaTime;
            transform.Rotate(rotation);

            // If no input, smoothly return to the initial rotation
            if (Mathf.Approximately(horizontalInput, 0f) && Mathf.Approximately(verticalInput, 0f))
            {
                transform.rotation = Quaternion.Slerp(transform.rotation, initialRotation, returnSpeed * Time.deltaTime);
            }
        }
    }

    void FixedUpdate()
    {
        // Check if the sphere is assigned
        if (sphere != null)
        {
            // Apply force to make the sphere slide down in the platform's forward direction
            Rigidbody sphereRb = sphere.GetComponent<Rigidbody>();
            if (sphereRb != null)
            {
                // Increase the rotationSpeed factor for faster sliding
                Vector3 slideForce = transform.forward * rotationSpeed * 70f * Time.fixedDeltaTime;
                sphereRb.AddForce(slideForce, ForceMode.Force);
            }
        }
    }
}
































//Mathf.Approximately(float a, float b): A function from the Mathf class in Unity. It checks whether two floating-point numbers are approximately equal
//Quaternion.Slerp(Quaternion a, Quaternion b, float t): This function performs spherical linear interpolation between two rotations (a and b). The third parameter, t, represents the interpolation factor and should be a value between 0 and 1.

