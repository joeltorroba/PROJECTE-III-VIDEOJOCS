using TMPro;
using UnityEngine;

public class VictoryPanelUI : MonoBehaviour
{
    [Header("Texts")]
    public TextMeshProUGUI chapasText;
    public TextMeshProUGUI distanciaText;
    public TextMeshProUGUI paracaidasText;

    private void OnEnable()
    {
        if (GameStats.Instance == null)
        {
            Debug.LogError("GameStats no encontrado");
            return;
        }

        Debug.Log("CHAPAS: " + GameStats.Instance.chapasRecogidas);
        Debug.Log("DISTANCIA: " + Mathf.RoundToInt(GameStats.Instance.distanciaRecorrida));
        Debug.Log("PARACAIDAS: " + GameStats.Instance.paracaidasRecogidos);

        if (chapasText != null)
        {
            chapasText.text = "+" + GameStats.Instance.chapasRecogidas;
        }

        if (distanciaText != null)
        {
            distanciaText.text =
                Mathf.RoundToInt(GameStats.Instance.distanciaRecorrida)
                + " / 1000 m";
        }

        if (paracaidasText != null)
        {
            paracaidasText.text =
                GameStats.Instance.paracaidasRecogidos + " / 3";
        }
    }
}