using System.Collections;
using UnityEngine;

public class TutorialManager : MonoBehaviour
{
    [Header("Configuración de Popups")]
    [Tooltip("Arrastra aquí los GameObjects de los popups en el orden en que deben aparecer.")]
    [SerializeField] private GameObject[] popups; 
    
    [Tooltip("Tiempo en segundos que avanza el juego entre popup y popup.")]
    [SerializeField] private float tiempoEntrePopups = 10f;

    private int indiceActual = 0;
    private bool esperandoInput = false;

    void Start()
    {
        // Nos aseguramos de que todo empiece oculto
        foreach (GameObject popup in popups)
        {
            if (popup != null) popup.SetActive(false);
        }

        // Arrancamos el flujo
        StartCoroutine(FlujoTutorial());
    }

    IEnumerator FlujoTutorial()
    {
        // Esperamos un segundo al arrancar la escena para que no salga el popup de golpe en la cara del jugador
        yield return new WaitForSeconds(1f);

        while (indiceActual < popups.Length)
        {
            if (popups[indiceActual] != null)
            {
                // 1. Pausamos el juego y mostramos el cartel
                Time.timeScale = 0f; 
                popups[indiceActual].SetActive(true);
                
                esperandoInput = true;

                // 2. Bucle de espera hasta que el jugador pulse "Skip"
                while (esperandoInput)
                {
                    yield return null; 
                }

                // 3. El jugador pulsó el botón: ocultamos cartel y reanudamos juego
                popups[indiceActual].SetActive(false);
                Time.timeScale = 1f; 
            }

            indiceActual++;

            // 4. Esperamos los 10 segundos de juego antes del siguiente popup
            if (indiceActual < popups.Length)
            {
                // Usamos WaitForSeconds normal porque queremos que mida el tiempo del juego corriendo a velocidad 1f
                yield return new WaitForSeconds(tiempoEntrePopups);
            }
        }

        Debug.Log("¡Felicidades! El sistema de tutorial ha terminado con éxito.");
    }

    // Este método lo asignas en el "On Click()" de tus botones de Skip
    public void AvanzarTutorial()
    {
        esperandoInput = false;
    }
}