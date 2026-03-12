using UnityEngine;
using System.Collections;

public class GoodObject : MonoBehaviour
{
    public float slowFallSpeed = 6f;
    public float effectDuration = 3f;

    private bool attached = false;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !attached)
        {
            GoodObject existingGood = other.GetComponentInChildren<GoodObject>();
            BadObject existingBad = other.GetComponentInChildren<BadObject>();

            // si hay malo → destruirlo
            if (existingBad != null)
            {
                Destroy(existingBad.gameObject);
            }

            // si hay otro bueno → destruirlo
            if (existingGood != null)
            {
                Destroy(existingGood.gameObject);
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
            fall.ModifyFallSpeed(slowFallSpeed, effectDuration);
        }

        transform.SetParent(player.transform);
        transform.localPosition = new Vector3(0, -1.5f, 0);

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