using UnityEngine;

public class MenuSkinSelector : MonoBehaviour
{
    public void SeleccionarSkin(int indiceSkin)
    {
        PlayerPrefs.SetInt("SkinEquipada", indiceSkin);
        PlayerPrefs.Save();

        Debug.Log("Skin seleccionada: " + indiceSkin);
    }
}