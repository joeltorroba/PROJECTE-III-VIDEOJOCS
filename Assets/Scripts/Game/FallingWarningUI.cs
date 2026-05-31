using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FallingWarningUI : MonoBehaviour
{
    public GameObject warningUIPrefab;

    private GameObject warningUI;
    private RectTransform rect;

    Camera cam;

    bool warningCreated = false;

    void Start()
    {
        cam = Camera.main;
    }

    void Update()
    {
        // SI ESTAMOS EN EL TUTORIAL Y TODAVÍA NO HEMOS LLEGADO
        // AL PASO DE OBJETOS MALOS, NO MOSTRAR NADA
        if (!warningCreated)
        {
            if (SceneManager.GetActiveScene().name == "TutorialScene")
            {
                if (!TutorialManager.canShowBadWarning)
                    return;
            }

            Canvas canvas = FindFirstObjectByType<Canvas>();

            warningUI = Instantiate(warningUIPrefab, canvas.transform);

            rect = warningUI.GetComponent<RectTransform>();

            warningCreated = true;
        }

        if (warningUI == null) return;

        float distanceToPlayer = Mathf.Abs(
            transform.position.y -
            GameObject.FindGameObjectWithTag("Player").transform.position.y
        );

        if (distanceToPlayer < 13f)
        {
            Destroy(warningUI);
            enabled = false;
            return;
        }

        Vector3 screenPos = cam.WorldToScreenPoint(transform.position);

        screenPos.y = Screen.height - 80f;

        screenPos.x = Mathf.Clamp(
            screenPos.x,
            50f,
            Screen.width - 50f
        );

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