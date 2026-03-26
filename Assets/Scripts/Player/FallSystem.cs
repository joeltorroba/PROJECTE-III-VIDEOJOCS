using UnityEngine;
using System.Collections;

public class FallSystem : MonoBehaviour
{
    public float fallSpeed = 10f;
    private float originalFallSpeed;
    private bool isBouncing = false;

    public Transform cameraTransform; // arrastra la cámara aquí en el inspector

    void Start()
    {
        originalFallSpeed = fallSpeed;
    }

    void Update()
    {
        if (!isBouncing)
        {
            Vector3 movement = Vector3.down * fallSpeed * Time.deltaTime;
            transform.position += movement;

            if (cameraTransform != null)
            {
                cameraTransform.position += movement;
            }
        }
    }

    public void ModifyFallSpeed(float newSpeed, float duration)
    {
        StopAllCoroutines();
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
        StopAllCoroutines();
        StartCoroutine(BounceCoroutine(height, duration));
    }

    IEnumerator BounceCoroutine(float height, float duration)
    {
        isBouncing = true;

        Vector3 startPosPlayer = transform.position;
        Vector3 targetPosPlayer = startPosPlayer + new Vector3(0, height, 0);

        Vector3 startPosCam = cameraTransform.position;
        Vector3 targetPosCam = startPosCam + new Vector3(0, height, 0);

        float time = 0f;

        while (time < duration)
        {
            transform.position = Vector3.Lerp(startPosPlayer, targetPosPlayer, time / duration);

            if (cameraTransform != null)
            {
                cameraTransform.position = Vector3.Lerp(startPosCam, targetPosCam, time / duration);
            }

            time += Time.deltaTime;
            yield return null;
        }

        transform.position = targetPosPlayer;

        if (cameraTransform != null)
        {
            cameraTransform.position = targetPosCam;
        }

        isBouncing = false;
    }
}