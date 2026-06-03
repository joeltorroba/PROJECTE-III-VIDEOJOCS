using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TimeFreezeSystem : MonoBehaviour
{
    public static TimeFreezeSystem instance;

    public static bool timeFrozen = false;

    public GameObject freezeEffect;

    public GameObject freezeHintUI;

    [Header("Freeze")]
    public float freezeDuration = 5f;

    [Header("UI")]
    public Image freezeUIFill;

    private bool hasFreezeStored = false;
    private Coroutine freezeRoutine;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        if (freezeUIFill != null)
        {
            freezeUIFill.transform.parent.gameObject.SetActive(false);
        }
    }

    void Update()
    {
        if (hasFreezeStored && Input.GetKeyDown(KeyCode.Q))
        {
            ActivateFreeze();
        }
    }

    public void StoreFreeze()
    {
        hasFreezeStored = true;

        if (freezeUIFill != null)
        {
            freezeUIFill.fillAmount = 1f;
            freezeUIFill.transform.parent.gameObject.SetActive(true);
        }

        StartCoroutine(ShowFreezeHint());
    }

    public void ActivateFreeze()
    {
        if (!hasFreezeStored)
            return;

        hasFreezeStored = false;

        if (freezeRoutine != null)
            StopCoroutine(freezeRoutine);

        freezeRoutine = StartCoroutine(FreezeCoroutine());
    }

    IEnumerator FreezeCoroutine()
    {
        timeFrozen = true;

        if (freezeEffect != null)
        {
            freezeEffect.SetActive(true);
        }


        float timer = freezeDuration;

        while (timer > 0)
        {
            timer -= Time.deltaTime;

            if (freezeUIFill != null)
            {
                freezeUIFill.fillAmount = timer / freezeDuration;
            }

            yield return null;
        }

        timeFrozen = false;

        if (freezeEffect != null)
        {
            freezeEffect.SetActive(false);
        }

        if (freezeUIFill != null)
        {
            freezeUIFill.transform.parent.gameObject.SetActive(false);
        }
    }

    IEnumerator ShowFreezeHint()
    {
        if (freezeHintUI == null)
            yield break;

        freezeHintUI.SetActive(true);

        yield return new WaitForSeconds(3f);

        freezeHintUI.SetActive(false);
    }
}