using UnityEngine;

public class CamaraSeguirJugador : MonoBehaviour
{
    public Transform jugador; 
    public float offsetY = 5f; // Ajusta a tu gusto para la altura
    public float offsetZ = -14f; // ¡NUEVO! La distancia hacia atrás fija que queremos mantener

    private float posX; 

    void Start()
    {
        posX = transform.position.x;
    }

    void LateUpdate()
    {
        if (jugador != null)
        {
            // Calculamos la Y perfecta
            float nuevaY = jugador.position.y + offsetY;

            // Calculamos la Z en base a donde esté el jugador en ese momento
            // Así, si el golpe mueve al jugador en la Z, la cámara se mueve con él y no se lo traga
            float nuevaZ = jugador.position.z + offsetZ;

            // Aplicamos la posición corregida
            transform.position = new Vector3(posX, nuevaY, nuevaZ);
        }
    }
}