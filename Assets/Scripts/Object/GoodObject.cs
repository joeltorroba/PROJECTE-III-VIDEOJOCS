using UnityEngine;
using System.Collections;

public class GoodObject : MonoBehaviour
{
    public bool isBounce = false;

    public float fallSpeedEffect = 6f;
    public float effectDuration = 3f;
    public AudioClip collectSound;
    public float volume = 1f;

    private bool attached = false;
    private Transform player;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !attached)
        {
            attached = true;
            player = other.transform;

            if (collectSound != null)
            {
                AudioSource.PlayClipAtPoint(
                    collectSound,
                    transform.position,
                    volume
                );
            }

            PlayerAnimationController animCtrl = other.GetComponent<PlayerAnimationController>();

           
            BadObject existingBad = other.GetComponentInChildren<BadObject>();
            if (existingBad != null)
            {
                existingBad.transform.SetParent(null); // Desemparentar primero
                Destroy(existingBad.gameObject);       // Borrar objeto malo
            }

            // Si ya tenías otro objeto bueno lo limpiamos también
            GoodObject existingGood = other.GetComponentInChildren<GoodObject>();
            if (existingGood != null && existingGood != this)
            {
                existingGood.transform.SetParent(null);
                Destroy(existingGood.gameObject);
            }

            // ACTIVAMOS LA ANIMACIÓN 
            if (animCtrl != null)
            {
                if (isBounce)
                    animCtrl.SetPropulse();   // Salto colchoneta
                else
                    animCtrl.SetLand();       // Planeo flotador/caja
            }

            // Aplicamos las nuevas velocidades del objeto bueno al jugador y a la cámara
            FallSystem playerFall = other.GetComponent<FallSystem>();
            FallSystem camFall = Camera.main.GetComponent<FallSystem>();

            if (playerFall != null)
                playerFall.ModifyFallSpeed(fallSpeedEffect, effectDuration);

            if (camFall != null)
                camFall.ModifyFallSpeed(fallSpeedEffect, effectDuration);

            if (isBounce)
            {
                Destroy(gameObject);
                return;
            }

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
        if (attached && player != null && !isBounce && transform.parent == player)
        {
            transform.position = player.position + new Vector3(0, 0.5f, 0);
        }
    }

    IEnumerator DestroyAfterTime()
    {
        yield return new WaitForSeconds(effectDuration);
        
        if (player != null)
        {
            PlayerAnimationController animCtrl = player.GetComponent<PlayerAnimationController>();
            if (animCtrl != null)
                animCtrl.SetEndEffect(); // El efecto termina y vuelve a caer normal si no hay interrupciones
        }
        
        Destroy(gameObject);
    }
}