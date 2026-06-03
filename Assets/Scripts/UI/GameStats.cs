using UnityEngine;

public class GameStats : MonoBehaviour
{
    public static GameStats Instance;

    public int chapasRecogidas;
    public int paracaidasRecogidos;
    public float distanciaRecorrida;

    private float alturaInicial;
    private Transform jugador;

    private void Awake()
    {
        Instance = this;
    }

    public void RegistrarJugador(Transform player)
    {
        jugador = player;
        alturaInicial = player.position.y;
    }

    private void Update()
    {
        if (jugador != null)
        {
            distanciaRecorrida = alturaInicial - jugador.position.y;

            if (distanciaRecorrida < 0)
                distanciaRecorrida = 0;
        }
    }

    public void Reiniciar()
    {
        chapasRecogidas = 0;
        paracaidasRecogidos = 0;
        distanciaRecorrida = 0;
    }
}