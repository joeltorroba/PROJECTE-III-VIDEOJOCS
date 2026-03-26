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
            attached = true;
            player = other.transform;

            FallSystem playerFall = other.GetComponent<FallSystem>();
            FallSystem camFall = Camera.main.GetComponent<FallSystem>();

            if (isBounce)
            {
                playerFall.Bounce(bounceHeight, 0.5f);
                if (camFall != null)
                    camFall.Bounce(bounceHeight, 0.5f);

                Destroy(gameObject);
                return;
            }

            // Ralentizar
            if (playerFall != null)
                playerFall.ModifyFallSpeed(slowFallSpeed, effectDuration);

            if (camFall != null)
                camFall.ModifyFallSpeed(slowFallSpeed, effectDuration);

            // Parar su caída
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
            // Siempre pegado debajo
            transform.position = player.position + new Vector3(0, -1.5f, 0);
        }
    }

    IEnumerator DestroyAfterTime()
    {
        yield return new WaitForSeconds(effectDuration);
        Destroy(gameObject);
    }
}