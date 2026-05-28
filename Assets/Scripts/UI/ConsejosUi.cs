using System.Collections;
using UnityEngine;
using TMPro;

public class ConsejosUI : MonoBehaviour
{
    public TMP_Text textoConsejo;

    [TextArea]
    public string[] consejos;

    public float tiempoCambio = 5f;

    private int indice = 0;

    void OnEnable()
    {
        StartCoroutine(CambiarConsejos());
    }

    IEnumerator CambiarConsejos()
    {
        while (true)
        {
            textoConsejo.text = consejos[indice];

            indice++;

            if (indice >= consejos.Length)
            {
                indice = 0;
            }

            // IMPORTANTE:
            yield return new WaitForSecondsRealtime(tiempoCambio);
        }
    }

    void OnDisable()
    {
        StopAllCoroutines();
    }
}