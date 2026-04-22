using UnityEngine;

public class GameOverOnGround : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            // ── ANTES llamabas GameManager directo
            // ── AHORA: primero la animación, luego GameOver
            PlayerAnimationController animCtrl =
                GetComponent<PlayerAnimationController>();

            if (animCtrl != null)
                animCtrl.SetDie();   // → Fall Flat Impact
            else
                GameManager.instance.GameOver(); // fallback si no hay anim
        }
    }
}