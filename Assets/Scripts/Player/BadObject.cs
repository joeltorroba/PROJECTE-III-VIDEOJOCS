using UnityEngine;
using System.Collections;

public class BadObject : MonoBehaviour
{
    public float heavyFallSpeed = 16f;
    public float effectDuration = 3f;

    private bool attached = false;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !attached)
        {
            BadObject existingBad = other.GetComponentInChildren<BadObject>();
            GoodObject existingGood = other.GetComponentInChildren<GoodObject>();

            // si hay bueno → destruirlo
            if (existingGood != null)
            {
                Destroy(existingGood.gameObject);
            }

            // si hay otro malo pegado → destruirlo (para evitar duplicados)
            if (existingBad != null)
            {
                Destroy(existingBad.gameObject);
            }

            AttachToPlayer(other);
        }
    }

    void AttachToPlayer(Collider player)
    {
        attached = true;

        FallSystem fall = player.GetComponent<FallSystem>();

        if (fall != null)
        {
            fall.ModifyFallSpeed(heavyFallSpeed, effectDuration);
        }

        transform.SetParent(player.transform);
        transform.localPosition = new Vector3(0, 1.5f, 0);

        Rigidbody rb = GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.isKinematic = true;
        }

        StartCoroutine(DestroyAfterEffect());
    }

    IEnumerator DestroyAfterEffect()
    {
        yield return new WaitForSeconds(3f);
        Destroy(gameObject);
    }
}