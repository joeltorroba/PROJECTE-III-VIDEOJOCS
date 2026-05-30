using UnityEngine;
using System.Collections; // Necesario para usar Coroutines

public class PlayerAnimationController : MonoBehaviour
{
    Animator anim;
    private Coroutine speedResetCoroutine;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void SetFalling()   { anim.SetTrigger("Falling"); }
    public void SetPropulse()  { anim.SetTrigger("Propulse"); }
    public void SetLand()      { anim.SetTrigger("Land"); }
    public void SetDie()       { anim.SetTrigger("Die"); }

    // Función modificada con temporizador automático por código
    public void SetHit(float tiempoEfecto)
    {
        anim.SetTrigger("Hit");

        // Obtenemos la duración real en segundos de tu clip en Blender
        float duracionClipOriginal = anim.GetCurrentAnimatorStateInfo(0).length;

        if (duracionClipOriginal > 0 && tiempoEfecto > 0)
        {
            anim.speed = duracionClipOriginal / tiempoEfecto;
        }

        // Si ya había un temporizador contando, lo paramos para empezar de nuevo
        if (speedResetCoroutine != null)
        {
            StopCoroutine(speedResetCoroutine);
        }

        // Iniciamos la cuenta atrás para devolver la velocidad a la normalidad
        speedResetCoroutine = StartCoroutine(ResetSpeedAfterTime(tiempoEfecto));
    }

    // Esta rutina espera a que el objeto desaparezca y resetea la velocidad
    IEnumerator ResetSpeedAfterTime(float delay)
    {
        yield return new WaitForSeconds(delay);
        anim.speed = 1f;
    }
}