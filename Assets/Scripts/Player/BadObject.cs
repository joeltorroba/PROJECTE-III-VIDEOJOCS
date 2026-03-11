using UnityEngine;
using System.Collections;

public class BadObject : MonoBehaviour
{
    public float heavyFallSpeed = 16f;
    public float effectDuration = 3f;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            FallSystem fall = other.GetComponent<FallSystem>();

            if (fall != null)
            {
                fall.ModifyFallSpeed(heavyFallSpeed, effectDuration);
            }

            StartCoroutine(DestroyAfterEffect());
        }
    }

    IEnumerator DestroyAfterEffect()
    {
        yield return new WaitForSeconds(3f);
        Destroy(gameObject);
    }
}