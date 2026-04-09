using UnityEngine;

public class SkyManager : MonoBehaviour
{
    public float skySpeed = 1.0f;
    public Vector3 offsetRotation = new Vector3(180, 0, 0); // Esto voltea el cielo

    void Update()
    {
        // Rotación continua
        float currentRotation = Time.time * skySpeed;
        RenderSettings.skybox.SetFloat("_Rotation", currentRotation);

        // Nota: Algunos shaders de Skybox no permiten rotar en X e Y fácilmente.
        // Si el cielo sigue arriba, lo mejor es usar la Opción 2 (el Plano de nubes).
    }
}