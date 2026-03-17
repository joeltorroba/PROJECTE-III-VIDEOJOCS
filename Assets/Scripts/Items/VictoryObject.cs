using UnityEngine;

public class VictoryObject : MonoBehaviour
{
    private bool gameFinished = false;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !gameFinished)
        {
            gameFinished = true;

            GameManager.instance.Victory();

            // parar el juego
            Time.timeScale = 0f;
        }
    }
}