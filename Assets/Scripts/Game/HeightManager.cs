using UnityEngine;
using TMPro;

public class HeightManager : MonoBehaviour
{
    public Transform player;
    public TextMeshProUGUI heightText;

    public float maxHeight = 300f;

    void Update()
    {
        if (Time.timeScale == 0f) return;

        float currentHeight = player.position.y;

        if (currentHeight < 0)
            currentHeight = 0;

        heightText.text = Mathf.FloorToInt(currentHeight) + " m";
    }
}