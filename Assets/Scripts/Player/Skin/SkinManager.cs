using UnityEngine;

public class SkinManager : MonoBehaviour
{
    [Header("Configuración del Personaje")]
   
    public SkinnedMeshRenderer personajeRenderer; 
    
    // Lista con 4 materiales 
    public Material[] misSkins; 

    private string llaveSkinGuardada = "SkinEquipada";

    void Start()
    {

        int skinActual = PlayerPrefs.GetInt(llaveSkinGuardada, 0);
        EquiparSkinVisual(skinActual);
    }

    
    private void EquiparSkinVisual(int indice)
    {
        if (indice >= 0 && indice < misSkins.Length && personajeRenderer != null)
        {
            personajeRenderer.material = misSkins[indice];
        }
    }

    
    public void SeleccionarYEquiparSkin(int indiceSkin)
    {
       
        EquiparSkinVisual(indiceSkin);

       
        PlayerPrefs.SetInt(llaveSkinGuardada, indiceSkin);
        PlayerPrefs.Save(); 

        Debug.Log("Skin " + indiceSkin + " guardada y lista para la partida.");
    }
}
