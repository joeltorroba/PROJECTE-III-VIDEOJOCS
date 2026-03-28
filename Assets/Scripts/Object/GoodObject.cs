using UnityEngine;
using System.Collections;

public class GoodObject : MonoBehaviour
{
    public bool isBounce = false;

    public float fallSpeedEffect = 6f;
    public float effectDuration = 3f;

    private bool attached = false;
    private Transform player;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !attached)
        {
            attached = true;
            player = other.transform;

            // 🔥 DESTRUIR BAD SI EXISTE
            BadObject existingBad = other.GetComponentInChildren<BadObject>();
            if (existingBad != null)
            {
                Destroy(existingBad.gameObject);
            }

            FallSystem playerFall = other.GetComponent<FallSystem>();
            FallSystem camFall = Camera.main.GetComponent<FallSystem>();

            // APLICAR EFECTO SIEMPRE
            if (playerFall != null)
                playerFall.ModifyFallSpeed(fallSpeedEffect, effectDuration);

            if (camFall != null)
                camFall.ModifyFallSpeed(fallSpeedEffect, effectDuration);

            // SI ES BOUNCE → DESAPARECE
            if (isBounce)
            {
                Destroy(gameObject);
                return;
            }

            // SI NO ES BOUNCE → SE PEGA
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
    }

    void Update()
    {
        if (attached && player != null && !isBounce)
        {
            transform.position = player.position + new Vector3(0, -1.5f, 0);
        }
    }

    IEnumerator DestroyAfterTime()
    {
        yield return new WaitForSeconds(effectDuration);
        Destroy(gameObject);
    }
}