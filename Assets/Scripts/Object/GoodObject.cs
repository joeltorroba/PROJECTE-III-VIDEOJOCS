using UnityEngine;
using System.Collections;

public class GoodObject : MonoBehaviour
{
    public enum EffectType
    {
        SlowFall,
        Bounce
    }

    public EffectType effectType;

    public float slowFallSpeed = 5f;
    public float effectDuration = 3f;
    public float bounceHeight = 5f;

    private bool used = false;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !used)
        {
            used = true;

            FallSystem fall = other.GetComponent<FallSystem>();

            // Cancelar malo si existe
            BadObject bad = other.GetComponentInChildren<BadObject>();
            if (bad != null)
            {
                Destroy(bad.gameObject);
            }

            // Cancelar otro bueno si existe
            GoodObject good = other.GetComponentInChildren<GoodObject>();
            if (good != null && good != this)
            {
                Destroy(good.gameObject);
            }

            if (effectType == EffectType.SlowFall)
            {
                fall.ModifyFallSpeed(slowFallSpeed, effectDuration);
                AttachToPlayer(other.transform);
                StartCoroutine(DestroyAfterTime(effectDuration));
            }
            else if (effectType == EffectType.Bounce)
            {
                fall.Bounce(bounceHeight, effectDuration);
                Destroy(gameObject); // la colchoneta NO se pega
            }
        }
    }

    void AttachToPlayer(Transform player)
    {
        transform.SetParent(player);
        transform.localPosition = new Vector3(0, -1.5f, 0);

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