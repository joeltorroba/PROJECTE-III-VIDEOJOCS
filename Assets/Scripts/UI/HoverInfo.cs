using UnityEngine;
using UnityEngine.EventSystems;

public class HoverInfo : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject aviso;

    public void OnPointerEnter(PointerEventData eventData)
    {
        aviso.SetActive(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        aviso.SetActive(false);
    }
}