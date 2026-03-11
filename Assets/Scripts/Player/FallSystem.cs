using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]
public class FallSystem : MonoBehaviour
{
    public float normalFallSpeed = 10f;

    private float currentFallSpeed;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.useGravity = false;

        currentFallSpeed = normalFallSpeed;
    }

    void FixedUpdate()
    {
        Vector3 velocity = rb.linearVelocity;
        velocity.y = -currentFallSpeed;
        rb.linearVelocity = velocity;
    }

    public void ModifyFallSpeed(float newSpeed, float duration)
    {
        StopAllCoroutines();
        StartCoroutine(FallSpeedEffect(newSpeed, duration));
    }

    IEnumerator FallSpeedEffect(float newSpeed, float duration)
    {
        currentFallSpeed = newSpeed;

        yield return new WaitForSeconds(duration);

        currentFallSpeed = normalFallSpeed;
    }
}