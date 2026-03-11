using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class FallSystem : MonoBehaviour
{
    private Rigidbody rb;

    [Header("Fall Settings")]
    public float fallSpeed = 10f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        ApplyFall();
    }

    void ApplyFall()
    {
        Vector3 velocity = rb.linearVelocity;
        velocity.y = -fallSpeed;
        rb.linearVelocity = velocity;
    }
}