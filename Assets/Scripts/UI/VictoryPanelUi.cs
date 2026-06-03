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

        if (chapasText != null)
        {
            chapasText.text = "+" + GameStats.Instance.chapasRecogidas;
        }

        if (distanciaText != null)
        {
            int distancia = Mathf.RoundToInt(GameStats.Instance.distanciaRecorrida);
            distanciaText.text = distancia + " m";
        }

        if (paracaidasText != null)
        {
            paracaidasText.text = GameStats.Instance.paracaidasRecogidos + " / 3";
        }
    }
}