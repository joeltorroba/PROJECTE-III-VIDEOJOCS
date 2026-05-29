using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [Header("Pantallas")]
    public GameObject menuPrincipal;
    public GameObject personalizar;

    public void PlayGame()
    {
        SceneManager.LoadScene("GameScene");
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