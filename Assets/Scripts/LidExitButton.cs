using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class LidExitButton : MonoBehaviour, IPointerDownHandler
{
    [SerializeField] private Canvas _canvas;
    [SerializeField] private Canvas _canvasDva;

    public void OnPointerDown(PointerEventData eventData)
    {
        _canvas.enabled = false;
        _canvasDva.gameObject.SetActive(true);
    }
}
