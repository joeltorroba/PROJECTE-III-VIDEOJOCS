using UnityEngine;
using System.Collections;

public class GoodObject : MonoBehaviour
{
    public float slowFallSpeed = 6f;
    public float effectDuration = 3f;
    public float bounceHeight = 5f;
    public bool isBounce = false;

    private bool attached = false;
    private Transform player;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !attached)
        {
            player = other.transform;

            FallSystem playerFall = other.GetComponent<FallSystem>();
            FallSystem camFall = Camera.main.GetComponent<FallSystem>();

            // 🔥 ELIMINAR EFECTOS ANTERIORES
            foreach (Transform child in player)
            {
                if (child.GetComponent<GoodObject>() != null || child.GetComponent<BadObject>() != null)
                {
                    Destroy(child.gameObject);
                }
            }

            // 🔥 BOUNCE
            if (isBounce)
            {
                if (playerFall != null)
                {
                    playerFall.Bounce(bounceHeight, 0.5f);
                }

                if (camFall != null)
                {
                    camFall.Bounce(bounceHeight, 0.5f);
                }

                Destroy(gameObject);
                return;
            }

            // 🔥 SLOW
            attached = true;

            if (playerFall != null)
            {
                playerFall.ModifyFallSpeed(slowFallSpeed, effectDuration);
            }

            if (camFall != null)
            {
                camFall.ModifyFallSpeed(slowFallSpeed, effectDuration);
            }

            // parar caída del objeto
            FallSystem myFall = GetComponent<FallSystem>();
            if (myFall != null)
            {
                myFall.enabled = false;
            }

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
            transform.position = player.position + new Vector3(0, -1.5f, 0);
        }
    }

    IEnumerator DestroyAfterTime()
    {
        yield return new WaitForSeconds(effectDuration);
        Destroy(gameObject);
    }
}