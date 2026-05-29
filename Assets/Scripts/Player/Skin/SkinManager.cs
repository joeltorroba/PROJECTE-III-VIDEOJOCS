using UnityEngine;

public class SkinManager : MonoBehaviour
{
    [Header("Configuración del Personaje")]
    // El componente del cuerpo del personaje donde arrastramos el material
    public SkinnedMeshRenderer personajeRenderer; 
    
    // Lista con tus 4 materiales (Original, Skin1, Skin2, Skin3)
    public Material[] misSkins; 

    private string llaveSkinGuardada = "SkinEquipada";

    void Start()
    {
        // Al empezar (ya sea en el menú o al iniciar la caída vertical),
        // cargamos la skin que el jugador dejó equipada. Por defecto es la 0 (Original).
        int skinActual = PlayerPrefs.GetInt(llaveSkinGuardada, 0);
        EquiparSkinVisual(skinActual);
    }

    // Función interna para cambiar el material en el modelo 3D
    private void EquiparSkinVisual(int indice)
    {
        if (indice >= 0 && indice < misSkins.Length && personajeRenderer != null)
        {
            personajeRenderer.material = misSkins[indice];
        }
    }

    // Esta es la función que llamarán tus botones de la tienda
    public void SeleccionarYEquiparSkin(int indiceSkin)
    {
        // 1. Cambiamos el aspecto visual al momento en la tienda
        EquiparSkinVisual(indiceSkin);

        // 2. Guardamos la elección para cuando empiece la partida (al darle al Play)
        PlayerPrefs.SetInt(llaveSkinGuardada, indiceSkin);
        PlayerPrefs.Save(); // Guarda el dato en el disco

        Debug.Log("Skin " + indiceSkin + " guardada y lista para la partida.");
    }
}
