using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    [Header("Música del Menú")]
    public AudioSource menuMusicSource;

    [Header("Efectos de Sonido")]
    public AudioSource sfxSource;
    public AudioClip clickSound;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }

    void Start()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
        ReproducirMusicaMenu();
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "IntroScene" || scene.name == "GameScene")
        {
            PararMusicaMenu();
        }
        else
        {
            ReproducirMusicaMenu();
        }
    }

    public void ReproducirMusicaMenu()
    {
        if (menuMusicSource != null && !menuMusicSource.isPlaying)
        {
            menuMusicSource.Play();
        }
    }

    public void PararMusicaMenu()
    {
        if (menuMusicSource != null && menuMusicSource.isPlaying)
        {
            menuMusicSource.Stop();
        }
    }

    public void PlayClick()
    {
        if (sfxSource != null && clickSound != null)
        {
            sfxSource.PlayOneShot(clickSound);
        }
    }

    void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}