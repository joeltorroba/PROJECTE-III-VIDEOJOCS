using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [Header("Pantallas")]
    public GameObject menuPrincipal;
    public GameObject personalizar;

    public void PlayGame()
    {
        SceneManager.LoadScene("IntroScene");
    }

    public void OpenPersonalizar()
    {
        menuPrincipal.SetActive(false);
        personalizar.SetActive(true);
    }

    public void VolverMenu()
    {
        personalizar.SetActive(false);
        menuPrincipal.SetActive(true);
    }

    public void Tutorial()
    {
        SceneManager.LoadScene("TutorialScene");
    }

    public void QuitGame()
    {
        Debug.Log("Salir del juego");
        Application.Quit();
    }
}