using UnityEngine;

public class CamaraSeguirJugador : MonoBehaviour
{
    public Transform jugador; 
    public float offsetY = 5f; 
    public float offsetZ = -14f; 
    private float posX; 

    void Start()
    {
        posX = transform.position.x;
    }

    void LateUpdate()
    {
        if (jugador != null)
        {
           
            float nuevaY = jugador.position.y + offsetY;

            
            float nuevaZ = jugador.position.z + offsetZ;

            
            transform.position = new Vector3(posX, nuevaY, nuevaZ);
        }
    }
}