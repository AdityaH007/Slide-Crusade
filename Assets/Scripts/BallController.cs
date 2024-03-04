using UnityEngine;

public class BallController : MonoBehaviour
{
    public float rollSpeed = 10f; // Adjust the speed of rolling as needed
    private Rigidbody rb;

    void Start()
    {
        // Get the Rigidbody component attached to the sphere
        rb = GetComponent<Rigidbody>();
        rb.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
        rb.useGravity = false; // Disable built-in gravity initially
    }

    void FixedUpdate()
    {
        // Enable gravity when the ball is on the slope
        if (IsOnSlope())
        {
            rb.useGravity = true;
            // Get the slope of the platform
            Vector3 slope = GetPlatformSlope();

            // Set the velocity to simulate rolling down the slope
            Vector3 velocity = slope * rollSpeed;
            velocity.y = rb.velocity.y; // Maintain the current y-axis velocity
            rb.velocity = velocity;
        }
        else
        {
            rb.useGravity = false; // Disable gravity when not on the slope
        }
    }

    bool IsOnSlope()
    {
        // Cast a ray from the center of the sphere to check if it's on the slope
        RaycastHit hit;
        return Physics.Raycast(transform.position, Vector3.down, out hit);
    }

    Vector3 GetPlatformSlope()
    {
        // Cast a ray from the center of the sphere to determine the slope of the platform
        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.down, out hit))
        {
            // Calculate the slope based on the normal of the hit point
            return Vector3.Cross(hit.normal, Vector3.up).normalized;
        }

        // Default slope if no hit is detected
        return Vector3.forward;
    }
}
