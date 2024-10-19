using UnityEngine;
using UnityEngine.EventSystems;

public class CoverPoint : MonoBehaviour, IPointerDownHandler
{
    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("Mouse clicked!");
    }
}