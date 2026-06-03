using UnityEngine;
using UnityEngine.SceneManagement;

public class SettingsManager : MonoBehaviour
{
    public void VolverMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void RestablecerAjustes()
    {
        PlayerPrefs.DeleteAll();
        PlayerPrefs.Save();

        Debug.Log("Ajustes restablecidos");
    }
}