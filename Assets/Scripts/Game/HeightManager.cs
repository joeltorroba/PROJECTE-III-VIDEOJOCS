using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class HeightManager : MonoBehaviour
{
    public Transform player;
    public TextMeshProUGUI heightText;
    public Slider heightBar;

    public float maxHeight = 300f;

    void Update()
    {
        if (Time.timeScale == 0f) return;

        float currentHeight = player.position.y;

        if (currentHeight < 0) currentHeight = 0;

        // texto
        heightText.text = "ALTURA: " + Mathf.FloorToInt(currentHeight) + " m";

        // barra
        heightBar.value = currentHeight;
    }
}