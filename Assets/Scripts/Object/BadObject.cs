using UnityEngine;
using System.Collections;

public class BadObject : MonoBehaviour
{
    public float fastFallSpeed = 20f;
    public float effectDuration = 3f;

    private bool attached = false;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !attached)
        {
            attached = true;

            FallSystem fall = other.GetComponent<FallSystem>();

            // Si hay un objeto bueno activo → destruirlo
            GoodObject good = other.GetComponentInChildren<GoodObject>();
            if (good != null)
            {
                Destroy(good.gameObject);
            }

            // Aplicar efecto de caída rápida
            if (fall != null)
            {
                fall.ModifyFallSpeed(fastFallSpeed, effectDuration);
            }

            // Pegarse encima del player
            AttachToPlayer(other.transform);

            // Destruir después del efecto
            StartCoroutine(DestroyAfterTime(effectDuration));
        }
    }

    void AttachToPlayer(Transform player)
    {
        transform.SetParent(player);
        transform.localPosition = new Vector3(0, 1.5f, 0); // Encima del player

        Rigidbody rb = GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.isKinematic = true;
        }
    }

    IEnumerator DestroyAfterTime(float time)
    {
        yield return new WaitForSeconds(time);
        Destroy(gameObject);
    }
}