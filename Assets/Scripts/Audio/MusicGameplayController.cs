using UnityEngine;

public class MusicGameplayController : MonoBehaviour
{
    [Header("Música Gameplay (Dinámica)")]
    public AudioSource hornDrippingSource;
    public AudioSource analogSynthGuitarSource;
    public AudioSource bassonsVioloncelliSource;
    public AudioSource skyRunnerSource;

    [Header("Ajustes de Mezcla")]
    [Range(0f, 1f)] public float volumenMaximoBase = 0.7f;
    [Range(0f, 1f)] public float volumenMaximoGuitar = 0.4f;

    private PlayerHealth playerHealth;
    private Transform playerTransform;
    private float maxHeight = 300f;

    void Start()
    {
        IniciarMusicaGameplay();
    }

    void Update()
    {
        if (playerHealth == null)
        {
            playerHealth = FindFirstObjectByType<PlayerHealth>();
            if (playerHealth != null)
            {
                playerTransform = playerHealth.transform;
            }

            HeightManager heightManager = FindFirstObjectByType<HeightManager>();
            if (heightManager != null)
            {
                maxHeight = heightManager.maxHeight;
            }
        }

        if (playerHealth != null && playerTransform != null)
        {
            float healthPercent = playerHealth.currentHealth / playerHealth.maxHealth;
            float currentHeight = playerTransform.position.y;
            if (currentHeight < 0) currentHeight = 0;
            float altitudePercent = Mathf.Clamp01(currentHeight / maxHeight);

            ActualizarMusicaDinamica(healthPercent, altitudePercent);
        }
    }

    void IniciarMusicaGameplay()
    {
        double startTime = AudioSettings.dspTime + 0.1f;

        if (hornDrippingSource != null) hornDrippingSource.PlayScheduled(startTime);
        if (analogSynthGuitarSource != null) analogSynthGuitarSource.PlayScheduled(startTime);
        if (bassonsVioloncelliSource != null) bassonsVioloncelliSource.PlayScheduled(startTime);
        if (skyRunnerSource != null) skyRunnerSource.PlayScheduled(startTime);

        if (hornDrippingSource != null) hornDrippingSource.volume = volumenMaximoBase;
        if (analogSynthGuitarSource != null) analogSynthGuitarSource.volume = volumenMaximoGuitar;
        if (bassonsVioloncelliSource != null) bassonsVioloncelliSource.volume = 0f;
        if (skyRunnerSource != null) skyRunnerSource.volume = 0f;
    }

    void ActualizarMusicaDinamica(float healthPercent, float altitudePercent)
    {
        if (hornDrippingSource != null) hornDrippingSource.volume = volumenMaximoBase;
        if (analogSynthGuitarSource != null) analogSynthGuitarSource.volume = healthPercent * volumenMaximoGuitar;
        if (bassonsVioloncelliSource != null) bassonsVioloncelliSource.volume = (1f - healthPercent) * volumenMaximoBase;

        float closenessToGround = 1f - altitudePercent;
        if (skyRunnerSource != null)
        {
            if (healthPercent > 0.4f)
            {
                skyRunnerSource.volume = closenessToGround * healthPercent * volumenMaximoBase;
            }
            else
            {
                skyRunnerSource.volume = Mathf.Lerp(skyRunnerSource.volume, 0f, Time.deltaTime * 2f);
            }
        }
    }

    void OnDestroy()
    {
        if (hornDrippingSource != null) hornDrippingSource.Stop();
        if (analogSynthGuitarSource != null) analogSynthGuitarSource.Stop();
        if (bassonsVioloncelliSource != null) bassonsVioloncelliSource.Stop();
        if (skyRunnerSource != null) skyRunnerSource.Stop();
    }
}