using UnityEngine;
using System.Collections;

public class BadObject : MonoBehaviour
{
    public float fastFallSpeed = 20f;
    public float effectDuration = 3f;

    private bool attached = false;
    private Transform player;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !attached)
        {
            player = other.transform;

            // 🔥 ELIMINAR CUALQUIER EFECTO ACTIVO
            foreach (Transform child in player)
            {
                if (child.GetComponent<GoodObject>() != null || child.GetComponent<BadObject>() != null)
                {
                    Destroy(child.gameObject);
                }
            }

            FallSystem playerFall = other.GetComponent<FallSystem>();
            FallSystem camFall = Camera.main.GetComponent<FallSystem>();

            attached = true;

            if (playerFall != null)
                playerFall.ModifyFallSpeed(fastFallSpeed, effectDuration);

            if (camFall != null)
                camFall.ModifyFallSpeed(fastFallSpeed, effectDuration);

            // parar caída
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