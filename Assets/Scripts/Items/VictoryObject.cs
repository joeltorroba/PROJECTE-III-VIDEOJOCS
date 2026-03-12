using UnityEngine;

public class VictoryObject : MonoBehaviour
{
    private bool gameFinished = false;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !gameFinished)
        {
            gameFinished = true;

            Debug.Log("VICTORIA");

            // parar el juego
            Time.timeScale = 0f;
        }
    }
}