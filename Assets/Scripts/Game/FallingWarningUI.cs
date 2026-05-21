using UnityEngine;
using UnityEngine.UI;

public class FallingWarningUI : MonoBehaviour
{
    public GameObject warningUIPrefab;

    private GameObject warningUI;
    private RectTransform rect;

    Camera cam;

    void Start()
    {
        cam = Camera.main;

        Canvas canvas = FindFirstObjectByType<Canvas>();

        warningUI = Instantiate(warningUIPrefab, canvas.transform);

        rect = warningUI.GetComponent<RectTransform>();
    }

    void Update()
    {
        if (warningUI == null) return;

        Vector3 viewportPos = cam.WorldToViewportPoint(transform.position);

        // Si ya entra en pantalla → borrar alerta
        float distanceToPlayer = Mathf.Abs(transform.position.y - GameObject.FindGameObjectWithTag("Player").transform.position.y);

        if (distanceToPlayer < 13f)
        {
            Destroy(warningUI);
            enabled = false;
            return;
        }

        Vector3 screenPos = cam.WorldToScreenPoint(transform.position);

        // Mantener arriba
        screenPos.y = Screen.height - 80f;

        // Limitar laterales
        screenPos.x = Mathf.Clamp(screenPos.x, 50f, Screen.width - 50f);

        rect.position = screenPos;
    }

    void OnDestroy()
    {
        if (warningUI != null)
        {
            Destroy(warningUI);
        }
    }
}