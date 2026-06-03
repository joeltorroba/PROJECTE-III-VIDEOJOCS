using UnityEngine;
using System.Collections;

public class BadObject : MonoBehaviour
{
    public float fallSpeedEffect = 18f;
    public float effectDuration = 3f;
    public float damage = 20f;
    public AudioClip hitSound;
    public float volume = 1f;

    public Vector3 attachOffset = new Vector3(0f, 1.5f, 0f);

    private bool attached = false;
    private Transform player;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !attached)
        {
            attached = true;
            player = other.transform;

            if (hitSound != null)
            {
                AudioSource.PlayClipAtPoint(
                    hitSound,
                    transform.position,
                    volume
                );
            }

            PlayerAnimationController animCtrl = other.GetComponent<PlayerAnimationController>();

            
            
            // Si hay un objeto malo viejo pegado
            BadObject existingBad = other.GetComponentInChildren<BadObject>();
            if (existingBad != null && existingBad != this)
            {
                existingBad.transform.SetParent(null); // Lo sacamos de la jerarquía ya
                Destroy(existingBad.gameObject);
            }

            // Si hay un objeto bueno pegado
            GoodObject existingGood = other.GetComponentInChildren<GoodObject>();
            if (existingGood != null)
            {
                existingGood.transform.SetParent(null); // 
                Destroy(existingGood.gameObject);
            }

            // ACTIVAMOS EL HIT 
            if (animCtrl != null)
            {
               animCtrl.SetHit(); // → Forza la animación de Fall Flat
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

            // Parar su propia caída por script
            FallSystem myFall = GetComponent<FallSystem>();
            if (myFall != null)
                myFall.enabled = false;

            // Buscamos el Rigidbody
            Rigidbody rbSolid = GetComponentInChildren<Rigidbody>();
            if (rbSolid != null)
            {
                rbSolid.isKinematic = false; 
                rbSolid.linearVelocity = Vector3.zero; 
            }

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
        
        if (player != null)
        {
            PlayerAnimationController animCtrl = player.GetComponent<PlayerAnimationController>();
            if (animCtrl != null)
                animCtrl.SetEndEffect(); 
        }
         
        Destroy(gameObject);
    }
}