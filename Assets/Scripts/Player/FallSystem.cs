using UnityEngine;
using System.Collections;

public class FallSystem : MonoBehaviour
{
    public float fallSpeed = 10f;
    private float originalFallSpeed;
    private bool isBouncing = false;

    void Start()
    {
        originalFallSpeed = fallSpeed;
    }

    void Update()
    {
        if (!isBouncing)
        {
            transform.position += Vector3.down * fallSpeed * Time.deltaTime;
        }
    }

    public void ModifyFallSpeed(float newSpeed, float duration)
    {
        StartCoroutine(SlowFallCoroutine(newSpeed, duration));
    }

    IEnumerator SlowFallCoroutine(float newSpeed, float duration)
    {
        fallSpeed = newSpeed;
        yield return new WaitForSeconds(duration);
        fallSpeed = originalFallSpeed;
    }

    public void Bounce(float height, float duration)
    {
        StartCoroutine(BounceCoroutine(height, duration));
    }

    IEnumerator BounceCoroutine(float height, float duration)
    {
        isBouncing = true;

        Vector3 startPos = transform.position;
        Vector3 targetPos = new Vector3(startPos.x, startPos.y + height, startPos.z);

        float time = 0f;

        while (time < duration)
        {
            transform.position = Vector3.Lerp(startPos, targetPos, time / duration);
            time += Time.deltaTime;
            yield return null;
        }

        transform.position = targetPos;
        isBouncing = false;
    }
}