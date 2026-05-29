using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ShieldSystem : MonoBehaviour
{
    public bool shieldActive = false;

    [Header("Shield")]
    public float shieldDuration = 15f;

    [Header("Visual")]
    public GameObject shieldBubble;

    [Header("UI")]
    public Image shieldUIFill;

    Coroutine shieldRoutine;

    void Start()
    {
        shieldBubble.SetActive(false);

        if (shieldUIFill != null)
            shieldUIFill.transform.parent.gameObject.SetActive(false);
    }

    public void ActivateShield()
    {
        if (shieldRoutine != null)
            StopCoroutine(shieldRoutine);

        shieldRoutine = StartCoroutine(ShieldCoroutine());
    }

    IEnumerator ShieldCoroutine()
    {
        shieldActive = true;

        shieldBubble.SetActive(true);

        if (shieldUIFill != null)
        {
            shieldUIFill.transform.parent.gameObject.SetActive(true);
        }

        float timer = shieldDuration;

        while (timer > 0)
        {
            timer -= Time.deltaTime;

            if (shieldUIFill != null)
            {
                shieldUIFill.fillAmount = timer / shieldDuration;
            }

            yield return null;
        }

        shieldActive = false;

        shieldBubble.SetActive(false);

        if (shieldUIFill != null)
        {
            shieldUIFill.transform.parent.gameObject.SetActive(false);
        }
    }
}