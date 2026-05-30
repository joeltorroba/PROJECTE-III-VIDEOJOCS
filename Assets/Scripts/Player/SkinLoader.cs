using UnityEngine;

public class SkinLoader : MonoBehaviour
{
    public SkinnedMeshRenderer personajeRenderer;
    public Material[] misSkins;

    void Start()
    {
        int skinActual = PlayerPrefs.GetInt("SkinEquipada", 0);

        if (skinActual >= 0 && skinActual < misSkins.Length)
        {
            personajeRenderer.material = misSkins[skinActual];
        }

        Debug.Log("Skin cargada: " + skinActual);
    }
}