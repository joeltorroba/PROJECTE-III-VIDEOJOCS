using UnityEngine;

public class PlayerEffects : MonoBehaviour
{
    public GameObject currentEffectObject;

    public void ApplyEffect(GameObject newEffectObject)
    {
        // Si ya hay efecto ? destruirlo
        if (currentEffectObject != null)
        {
            Destroy(currentEffectObject);
        }

        // Guardar nuevo efecto
        currentEffectObject = newEffectObject;
    }

    public void ClearEffect(GameObject effectObject)
    {
        if (currentEffectObject == effectObject)
        {
            currentEffectObject = null;
        }
    }
}