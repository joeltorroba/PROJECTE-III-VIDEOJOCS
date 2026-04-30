using UnityEngine;
using System.Collections;

public class BadObject : MonoBehaviour
{
    public float fallSpeedEffect = 18f;
    public float effectDuration = 3f;
    public float damage = 20f;

    public Vector3 attachOffset = new Vector3(0f, 1.5f, 0f);

    private bool attached = false;
    private Transform player;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !attached)
        {
            attached = true;
            player = other.transform;

            // Si ya hay otro objeto malo pegado, eliminarlo
            BadObject existingBad = other.GetComponentInChildren<BadObject>();
            if (existingBad != null && existingBad != this)
            {
                Destroy(existingBad.gameObject);
            }

            // Si hay un objeto bueno pegado, eliminarlo
            GoodObject existingGood = other.GetComponentInChildren<GoodObject>();
            if (existingGood != null)
            {
                Destroy(existingGood.gameObject);
            }

            // Quitar vida
            PlayerHealth health = other.GetComponent<PlayerHealth>();
            if (health != null)
            {
                health.TakeDamage(damage);
                ScreenShake shake = FindFirstObjectByType<ScreenShake>();
                if (shake != null)
                {
                    shake.Shake();
                }
            }

            // Aplicar velocidad de caída
            FallSystem playerFall = other.GetComponent<FallSystem>();
            FallSystem camFall = Camera.main.GetComponent<FallSystem>();

            if (playerFall != null)
                playerFall.ModifyFallSpeed(fallSpeedEffect, effectDuration);

            if (camFall != null)
                camFall.ModifyFallSpeed(fallSpeedEffect, effectDuration);

            // Parar su propia caída
            FallSystem myFall = GetComponent<FallSystem>();
            if (myFall != null)
                myFall.enabled = false;

            // Pegarse al player
            transform.SetParent(player);

            StartCoroutine(DestroyAfterTime());
        }

        if (other.CompareTag("Ground"))
        {
            Destroy(gameObject);
        }
    }

    void Update()
    {
        if (attached && player != null)
        {
            transform.position = player.position + attachOffset;
        }
    }

    IEnumerator DestroyAfterTime()
    {
        yield return new WaitForSeconds(effectDuration);
        Destroy(gameObject);
    }
}