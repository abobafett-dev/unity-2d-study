using UnityEngine;

public class CanvasPlacer : MonoBehaviour
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
}