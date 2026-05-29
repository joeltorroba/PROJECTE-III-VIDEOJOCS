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

    IEnumerator FadeIn(CanvasGroup canvasGroup)
    {
        canvasGroup.alpha = 0f;

        while (canvasGroup.alpha < 1f)
        {
            canvasGroup.alpha += Time.deltaTime * 5f;
            yield return null;
        }

        canvasGroup.alpha = 1f;
    }

    public void MostrarVerde()
    {
        Verde.SetActive(true);
        Artico.SetActive(false);
        Rojo.SetActive(false);
        Oro.SetActive(false);

        StartCoroutine(FadeIn(verdeCanvas));
    }

    public void MostrarArtico()
    {
        Verde.SetActive(false);
        Artico.SetActive(true);
        Rojo.SetActive(false);
        Oro.SetActive(false);

        StartCoroutine(FadeIn(articoCanvas));
    }

    public void MostrarRojo()
    {
        Verde.SetActive(false);
        Artico.SetActive(false);
        Rojo.SetActive(true);
        Oro.SetActive(false);

        StartCoroutine(FadeIn(rojoCanvas));
    }

    public void MostrarOro()
    {
        Verde.SetActive(false);
        Artico.SetActive(false);
        Rojo.SetActive(false);
        Oro.SetActive(true);

        StartCoroutine(FadeIn(oroCanvas));
    }
}