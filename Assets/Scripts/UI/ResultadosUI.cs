using UnityEngine;
using TMPro;

public class ResultadosUI : MonoBehaviour
{
    public TMP_Text textoTiempo;
    public TMP_Text textoDistancia;

    public void MostrarResultados(float tiempoTotal, float distanciaFinal)
    {
        // FORMATO TIEMPO
        int minutos = Mathf.FloorToInt(tiempoTotal / 60);
        int segundos = Mathf.FloorToInt(tiempoTotal % 60);

        textoTiempo.text = minutos.ToString("00") + ":" + segundos.ToString("00");

        // DISTANCIA
        textoDistancia.text = distanciaFinal.ToString("F0") + " m";
    }
}