using UnityEngine;
using TMPro;

public class TotalCoinsUI : MonoBehaviour
{
    public TextMeshProUGUI totalCoinsText;

    void Start()
    {
        int totalCoins = PlayerPrefs.GetInt("TotalCoins", 0);

        totalCoinsText.text = totalCoins.ToString();
    }
}