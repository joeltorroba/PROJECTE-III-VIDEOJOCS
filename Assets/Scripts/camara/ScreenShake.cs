using UnityEngine;
using System.Collections;

public class ScreenShake : MonoBehaviour
{
    public float duration = 0.15f;
    public float magnitude = 0.2f;

    private Vector3 originalPos;
    private bool isShaking = false;

    void Awake()
    {
        originalPos = transform.localPosition;
    }

    public void Shake()
    {
        if (!isShaking)
            StartCoroutine(ShakeCoroutine());
    }

    IEnumerator ShakeCoroutine()
    {
        isShaking = true;
        float elapsed = 0f;

        originalPos = transform.localPosition;

        while (elapsed < duration)
        {
            float x = Random.Range(-1f, 1f) * magnitude;
            float y = Random.Range(-1f, 1f) * magnitude;

            transform.localPosition = originalPos + new Vector3(x, y, 0);

            elapsed += Time.deltaTime;
            yield return null;
        }

        transform.localPosition = originalPos;
        isShaking = false;
    }
}