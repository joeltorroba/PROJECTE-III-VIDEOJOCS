using UnityEngine;

public class MusicGameplayController : MonoBehaviour
{
    [Header("Musica Gameplay (Dinamica)")]
    public AudioSource hornDrippingSource;
    public AudioSource analogSynthGuitarSource;
    public AudioSource bassonsVioloncelliSource;
    public AudioSource skyRunnerSource;

    [Header("Ajustes de Mezcla Global")]
    [Range(0f, 1f)] public float volumenGeneralMaster = 0.22f; // Subido un pel�n (de 0.15 a 0.22)

    [Header("L�mites por Instrumento")]
    [Range(0f, 1f)] public float maxHornBase = 0.8f;
    [Range(0f, 1f)] public float maxGuitar = 0.5f;
    [Range(0f, 1f)] public float maxVioloncelli = 0.9f;
    [Range(0f, 1f)] public float maxSkyRunner = 0.7f;

    [Header("Multiplicador de Tensi�n")]
    [Range(1f, 3f)] public float multiplicadorVioloncelliTension = 1.5f; // Fuerza un extra a los chelos malos

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

        if (hornDrippingSource != null) hornDrippingSource.volume = maxHornBase * volumenGeneralMaster;
        if (analogSynthGuitarSource != null) analogSynthGuitarSource.volume = maxGuitar * volumenGeneralMaster;
        if (bassonsVioloncelliSource != null) bassonsVioloncelliSource.volume = 0f;
        if (skyRunnerSource != null) skyRunnerSource.volume = 0f;
    }

    void ActualizarMusicaDinamica(float healthPercent, float altitudePercent)
    {
        if (hornDrippingSource != null)
            hornDrippingSource.volume = maxHornBase * volumenGeneralMaster;

        if (analogSynthGuitarSource != null)
            analogSynthGuitarSource.volume = healthPercent * maxGuitar * volumenGeneralMaster;

        if (bassonsVioloncelliSource != null)
        {
            // Calcula el volumen din�mico y le aplica el multiplicador de tensi�n extra
            float volVioloncelli = (1f - healthPercent) * maxVioloncelli * volumenGeneralMaster * multiplicadorVioloncelliTension;
            bassonsVioloncelliSource.volume = Mathf.Clamp01(volVioloncelli);
        }

        float closenessToGround = 1f - altitudePercent;
        if (skyRunnerSource != null)
        {
            if (healthPercent > 0.4f)
            {
                skyRunnerSource.volume = closenessToGround * healthPercent * maxSkyRunner * volumenGeneralMaster;
            }
            else
            {
                skyRunnerSource.volume = Mathf.Lerp(skyRunnerSource.volume, 0f, Time.deltaTime * 4f);
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