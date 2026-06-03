using UnityEngine;
using UnityEngine.SceneManagement;

public class SettingsManager : MonoBehaviour
{
    public void VolverMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}