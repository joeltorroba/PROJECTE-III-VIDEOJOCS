using UnityEngine;

public class GameStats : MonoBehaviour
{
    public static GameStats Instance;

    public int chapasRecogidas;
    public int paracaidasRecogidos;
    public float distanciaRecorrida;

    private void Awake()
    {
        Instance = this;
    }

    public void Reiniciar()
    {
        chapasRecogidas = 0;
        paracaidasRecogidos = 0;
        distanciaRecorrida = 0;
    }
}