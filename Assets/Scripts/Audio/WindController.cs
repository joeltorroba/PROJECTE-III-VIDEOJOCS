using UnityEngine;

public class WindController : MonoBehaviour
{
    [Header("Efecto de Ambiente")]
    public AudioSource windSource;

    void Start()
    {
        if (windSource != null)
        {
            windSource.loop = true;
            windSource.volume = 0.5f;
            windSource.playOnAwake = false;
            windSource.Play();
        }
    }

    void OnDestroy()
    {
        if (windSource != null)
        {
            windSource.Stop();
        }
    }
}