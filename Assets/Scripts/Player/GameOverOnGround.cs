using UnityEngine;

public class GameOverOnGround : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            GameOver();
        }
    }

    void GameOver()
    {
        GameManager.instance.GameOver();

        // Detener el juego
        Time.timeScale = 0f;
    }
}