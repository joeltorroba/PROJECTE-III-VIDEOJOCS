using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public GameObject menuPrincipal;
    public GameObject personalizar;

    public void PlayGame()
    {
        // Tu código
    }

    public void OpenPersonalizar()
    {
        menuPrincipal.SetActive(false);
        personalizar.SetActive(true);
    }

    public void QuitGame()
    {
        Debug.Log("Salir del juego");
        Application.Quit();
    }
}