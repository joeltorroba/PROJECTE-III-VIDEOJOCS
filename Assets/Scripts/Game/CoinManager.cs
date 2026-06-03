using UnityEngine;
using TMPro;

public class CoinManager : MonoBehaviour
{
    public static CoinManager instance;

    [Header("UI")]
    public TextMeshProUGUI runCoinsText;
    public TextMeshProUGUI totalCoinsText;

    private int runCoins = 0;
    private int totalCoins = 0;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        totalCoins = PlayerPrefs.GetInt("TotalCoins", 0);

        UpdateUI();
    }

    public void AddCoin(int amount)
    {
        runCoins += amount;
        totalCoins += amount;

        // Estadísticas de la partida actual
        if (GameStats.Instance != null)
        {
            GameStats.Instance.chapasRecogidas += amount;
        }

        PlayerPrefs.SetInt("TotalCoins", totalCoins);
        PlayerPrefs.Save();

        UpdateUI();
    }

    void UpdateUI()
    {
        if (runCoinsText != null)
            runCoinsText.text = runCoins.ToString();

        if (totalCoinsText != null)
            totalCoinsText.text = totalCoins.ToString();
    }

    public int GetTotalCoins()
    {
        return totalCoins;
    }

    public int GetRunCoins()
    {
        return runCoins;
    }

    public void ResetRunCoins()
    {
        runCoins = 0;
        UpdateUI();
    }
}