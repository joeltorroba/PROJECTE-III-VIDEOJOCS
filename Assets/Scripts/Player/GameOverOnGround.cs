using UnityEngine;

public class GameOverOnGround : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            FallSystem fall = GetComponent<FallSystem>();
            if (fall != null)
            {
                fall.FreezeFall();
            }

            // Destruir todos los objetos que caen
            GameObject[] fallingObjects = GameObject.FindGameObjectsWithTag("FallingObject");
            foreach (GameObject obj in fallingObjects)
            {
                Destroy(obj);
            }

            // Desactivar todos los spawners
            GameObject[] spawners = GameObject.FindGameObjectsWithTag("Spawner");
            foreach (GameObject spawner in spawners)
            {
                spawner.SetActive(false);
            }

            PlayerAnimationController animCtrl = GetComponent<PlayerAnimationController>();

            if (animCtrl != null)
                animCtrl.SetDie();
            else
                GameManager.instance.GameOver();
        }
    }
}