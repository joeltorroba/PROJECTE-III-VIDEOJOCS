using UnityEngine;

public class PauseMenuAudio : MonoBehaviour
{
    [Header("Efectos de Sonido")]
    public AudioSource sfxSource;
    public AudioClip clickSound;

    // Cuando se abre la pausa, no hace falta reproducir música de menú
    void OnEnable()
    {
        // Se queda limpio y en silencio
    }

    // Cuando se cierra la pausa, nos aseguramos de que el juego recupere su sonido normal
    void OnDisable()
    {
        MusicGameplayController gameplayMusic = FindFirstObjectByType<MusicGameplayController>();
        if (gameplayMusic != null)
        {
            gameplayMusic.enabled = false;
            gameplayMusic.enabled = true;
        }
    }

    // Esta es la función pública que dejas en el "On Click()" de tus botones
    public void PlayClick()
    {
        if (sfxSource != null && clickSound != null)
        {
            sfxSource.PlayOneShot(clickSound);
        }
    }
}