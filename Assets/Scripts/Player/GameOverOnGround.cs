using UnityEngine;

public class GameOverOnGround : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            // Parar la caída
            FallSystem fall = GetComponent<FallSystem>();
            if (fall != null)
            {
                fall.enabled = false;
            }

            // Animación de impacto
            PlayerAnimationController animCtrl = GetComponent<PlayerAnimationController>();

            if (animCtrl != null)
                animCtrl.SetDie();   // → Fall Flat Impact
            else
                GameManager.instance.GameOver(); // fallback si no hay anim
        }
    }
}