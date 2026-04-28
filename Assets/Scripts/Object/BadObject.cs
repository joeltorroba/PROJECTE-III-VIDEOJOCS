using UnityEngine;
using System.Collections;

public class BadObject : MonoBehaviour
{
    public float fallSpeedEffect = 18f;
    public float effectDuration = 3f;

    private bool attached = false;
    private Transform player;
    public float damage = 20f;
   

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !attached)
        {
            attached = true;
            player = other.transform;
              // ── ANIMACIÓN ───────────────
            PlayerAnimationController animCtrl =
                other.GetComponent<PlayerAnimationController>();

                if (animCtrl != null)
                {
                    animCtrl.SetHit();   // → activa Fall Flat
                }
            // 🔥 DESTRUIR GOOD SI EXISTE
            GoodObject existingGood = other.GetComponentInChildren<GoodObject>();
            if (existingGood != null)
            {
                Destroy(existingGood.gameObject);
            }

            FallSystem playerFall = other.GetComponent<FallSystem>();
            FallSystem camFall = Camera.main.GetComponent<FallSystem>();

            if (playerFall != null)
                playerFall.ModifyFallSpeed(fallSpeedEffect, effectDuration);

            if (camFall != null)
                camFall.ModifyFallSpeed(fallSpeedEffect, effectDuration);

            // PEGARSE ARRIBA
            FallSystem myFall = GetComponent<FallSystem>();
            if (myFall != null)
                myFall.enabled = false;

            transform.SetParent(player);

            StartCoroutine(DestroyAfterTime());
        }

        if (other.CompareTag("Ground"))
        {
            Destroy(gameObject);
        }

        PlayerHealth health = other.GetComponent<PlayerHealth>();
        if (health != null)
        {
            health.TakeDamage(damage); // daño del objeto
        }
    }

    void Update()
    {
        if (attached && player != null)
        {
            transform.position = player.position + new Vector3(0, 1.5f, 0);
        }
    }

    IEnumerator DestroyAfterTime()
    {
        yield return new WaitForSeconds(effectDuration);
        Destroy(gameObject);
    }
}