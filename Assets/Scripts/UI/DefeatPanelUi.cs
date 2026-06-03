using TMPro;
using UnityEngine;

public class DefeatPanelUI : MonoBehaviour
{
    public TextMeshProUGUI chapasText;
    public TextMeshProUGUI distanciaText;
    public TextMeshProUGUI paracaidasText;

    private void OnEnable()
    {
        chapasText.text = "+" + GameStats.Instance.chapasRecogidas;

        distanciaText.text =
            Mathf.RoundToInt(GameStats.Instance.distanciaRecorrida)
            + " / 1000 m";

        paracaidasText.text =
            GameStats.Instance.paracaidasRecogidos + " / 3";
    }
}