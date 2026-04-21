using UnityEngine;
using UnityEngine.UI;

public class ParachuteManager : MonoBehaviour
{
    public static ParachuteManager instance;

    [Header("Progress")]
    public int currentPieces = 0;
    public int requiredPieces = 3;

    [Header("UI")]
    public Image parachuteFillImage; // imagen circular tipo Filled
    public GameObject parachuteUIRoot; // para mostrarla cuando coges el primero

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        UpdateUI();
    }

    public void CollectParachutePiece()
    {
        if (currentPieces >= requiredPieces)
            return;

        currentPieces++;

        UpdateUI();

        if (currentPieces >= requiredPieces)
        {
            GameManager.instance.Victory();
        }
    }

    void UpdateUI()
    {
        if (parachuteUIRoot != null)
        {
            parachuteUIRoot.SetActive(currentPieces > 0);
        }

        if (parachuteFillImage != null)
        {
            parachuteFillImage.fillAmount = (float)currentPieces / requiredPieces;
        }
    }

    public void HideUI()
    {
        if (parachuteUIRoot != null)
        {
            parachuteUIRoot.SetActive(false);
        }
    }
}
