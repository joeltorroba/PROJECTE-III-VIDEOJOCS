using System.Collections;
using UnityEngine;

public class PersonalizarManager : MonoBehaviour
{
    [Header("Pantallas")]
    public GameObject Verde;
    public GameObject Artico;
    public GameObject Rojo;
    public GameObject Oro;

    [Header("Canvas Groups")]
    public CanvasGroup verdeCanvas;
    public CanvasGroup articoCanvas;
    public CanvasGroup rojoCanvas;
    public CanvasGroup oroCanvas;

    private void Start()
    {
        MostrarVerde();
    }

    IEnumerator FadeIn(CanvasGroup canvasGroup, Transform objeto)
    {
        canvasGroup.alpha = 0f;
        objeto.localScale = Vector3.one * 0.92f;

        while (canvasGroup.alpha < 1f)
        {
            canvasGroup.alpha += Time.deltaTime * 1.8f;

            objeto.localScale = Vector3.Lerp(
                objeto.localScale,
                Vector3.one,
                Time.deltaTime * 4f
            );

            yield return null;
        }

        canvasGroup.alpha = 1f;
        objeto.localScale = Vector3.one;
    }

    public void MostrarVerde()
    {
        Verde.SetActive(true);
        Artico.SetActive(false);
        Rojo.SetActive(false);
        Oro.SetActive(false);

        StartCoroutine(FadeIn(verdeCanvas, Verde.transform));
    }

    public void MostrarArtico()
    {
        Verde.SetActive(false);
        Artico.SetActive(true);
        Rojo.SetActive(false);
        Oro.SetActive(false);

        StartCoroutine(FadeIn(articoCanvas, Artico.transform));
    }

    public void MostrarRojo()
    {
        Verde.SetActive(false);
        Artico.SetActive(false);
        Rojo.SetActive(true);
        Oro.SetActive(false);

        StartCoroutine(FadeIn(rojoCanvas, Rojo.transform));
    }

    public void MostrarOro()
    {
        Verde.SetActive(false);
        Artico.SetActive(false);
        Rojo.SetActive(false);
        Oro.SetActive(true);

        StartCoroutine(FadeIn(oroCanvas, Oro.transform));
    }
}