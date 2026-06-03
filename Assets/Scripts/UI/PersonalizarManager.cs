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
        Verde.SetActive(true);
        Artico.SetActive(false);
        Rojo.SetActive(false);
        Oro.SetActive(false);
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
        PlayerPrefs.SetInt("SkinEquipada", 0);
        PlayerPrefs.Save();

        Verde.SetActive(true);
        Artico.SetActive(false);
        Rojo.SetActive(false);
        Oro.SetActive(false);

        StartCoroutine(FadeIn(verdeCanvas));

        Debug.Log("Skin guardada: 0");
    }

    public void MostrarArtico()
    {
        PlayerPrefs.SetInt("SkinEquipada", 1);
        PlayerPrefs.Save();

        Verde.SetActive(false);
        Artico.SetActive(true);
        Rojo.SetActive(false);
        Oro.SetActive(false);

        StartCoroutine(FadeIn(articoCanvas));

        Debug.Log("Skin guardada: 1");
    }

    public void MostrarRojo()
    {
        PlayerPrefs.SetInt("SkinEquipada", 2);
        PlayerPrefs.Save();

        Verde.SetActive(false);
        Artico.SetActive(false);
        Rojo.SetActive(true);
        Oro.SetActive(false);

        StartCoroutine(FadeIn(rojoCanvas));

        Debug.Log("Skin guardada: 2");
    }

    public void MostrarOro()
    {
        PlayerPrefs.SetInt("SkinEquipada", 3);
        PlayerPrefs.Save();

        Verde.SetActive(false);
        Artico.SetActive(false);
        Rojo.SetActive(false);
        Oro.SetActive(true);

        StartCoroutine(FadeIn(oroCanvas));

        Debug.Log("Skin guardada: 3");
    }
}