using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;

    [Header("Movement")]
    public float acceleration = 20f;
    public float maxSpeed = 8f;
    public float drag = 5f;

    [Header("Screen Limits")]
    public float leftLimit = -8f;
    public float rightLimit = 8f;

    private float input;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // Leer input del jugador
        input = Input.GetAxis("Horizontal");
    }

    void FixedUpdate()
    {
        Move();
        ApplyDrag();
        LimitSpeed();
        LimitPosition();
    }

    void Move()
    {
        Vector3 force = new Vector3(input * acceleration, 0f, 0f);
        rb.AddForce(force, ForceMode.Acceleration);
    }

    void ApplyDrag()
    {
        if (Mathf.Abs(input) < 0.1f)
        {
            Vector3 velocity = rb.linearVelocity;
            velocity.x = Mathf.Lerp(velocity.x, 0f, drag * Time.fixedDeltaTime);
            rb.linearVelocity = velocity;
        }
    }

    void LimitSpeed()
    {
        Vector3 velocity = rb.linearVelocity;
        velocity.x = Mathf.Clamp(velocity.x, -maxSpeed, maxSpeed);
        rb.linearVelocity = velocity;
    }

    void LimitPosition()
    {
        Vector3 pos = transform.position;
        pos.x = Mathf.Clamp(pos.x, leftLimit, rightLimit);
        transform.position = pos;
    }
}