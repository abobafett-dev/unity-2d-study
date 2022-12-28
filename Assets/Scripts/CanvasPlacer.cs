using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class CanvasPlacer : MonoBehaviour, IPointerEnterHandler
{
    void Start()
    {
        CanvasShow.Show += ShowButton;
    }

    private void ShowButton(bool value)
    {
        var gg = GetComponent<Canvas>();
        gg.enabled = value;
    }

    private void OnDestroy()
    {
        CanvasShow.Show -= ShowButton;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log("Навёл");
    }
}
