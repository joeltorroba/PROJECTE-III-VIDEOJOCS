using UnityEngine;

public class CamaraSeguirJugador : MonoBehaviour
{
    public Transform jugador; // Arrastra aquí el objeto jugador
    public float offsetY = 2f; // Distancia vertical sobre el jugador

    private float posX; // Para mantener X fijo
    private float posZ; // Para mantener Z fijo (si usas 3D)

    void Start()
    {
        // Guardamos la posición inicial X y Z de la cámara
        posX = transform.position.x;
        posZ = transform.position.z;
    }

    void LateUpdate()
    {
        if (jugador != null)
        {
            // Solo seguimos la Y del jugador
            float nuevaY = jugador.position.y + offsetY;

            // Actualizamos la posición de la cámara
            transform.position = new Vector3(posX, nuevaY, posZ);
        }
    }
}