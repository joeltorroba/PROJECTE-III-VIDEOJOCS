using UnityEngine;

[System.Serializable]
public class TutorialStep
{
    public string stepName;

    [Header("Activación")]
    public float triggerHeight;

    [Header("UI")]
    public GameObject panel;

    [Header("Comportamiento")]
    public bool pauseGame = false;

    [Header("Auto ocultar")]
    public float hideAfterSeconds = 4f;

    [HideInInspector]
    public bool hasTriggered = false;
}

public class TutorialManager : MonoBehaviour
{
    // ← ESTA VARIABLE ES LA NUEVA
    public static bool canShowBadWarning = false;

    public Transform player;

    public TutorialStep[] steps;

    void Start()
    {
        canShowBadWarning = false;

        foreach (TutorialStep step in steps)
        {
            if (step.panel != null)
                step.panel.SetActive(false);
        }
    }

    void Update()
    {
        float currentHeight = player.position.y;

        foreach (TutorialStep step in steps)
        {
            if (step.hasTriggered)
                continue;

            if (currentHeight <= step.triggerHeight)
            {
                ActivateStep(step);
            }
        }
    }

    void ActivateStep(TutorialStep step)
    {
        step.hasTriggered = true;

        // ← AQUÍ ESTÁ LA MAGIA
        // Cuando llegue el paso llamado "Bad Object"
        // se activan los warnings
        if (step.stepName == "Bad Object")
        {
            canShowBadWarning = true;
        }

        if (step.panel != null)
            step.panel.SetActive(true);

        if (step.pauseGame)
        {
            Time.timeScale = 0;
        }
        else
        {
            if (step.hideAfterSeconds > 0)
            {
                StartCoroutine(HidePanel(step));
            }
        }
    }

    System.Collections.IEnumerator HidePanel(TutorialStep step)
    {
        yield return new WaitForSeconds(step.hideAfterSeconds);

        if (step.panel != null)
            step.panel.SetActive(false);
    }

    public void ContinueTutorial()
    {
        Debug.Log("BOTON FUNCIONA");

        Time.timeScale = 1;

        foreach (TutorialStep step in steps)
        {
            if (step.panel != null)
            {
                step.panel.SetActive(false);
            }
        }
    }
}