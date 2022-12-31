using UnityEngine;
using UnityEngine.EventSystems;

public class Bolt : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler
{
    public delegate void TriggerEvent();

    public static event TriggerEvent PickUp;

    private bool _screwdriverIsReady;

    protected void Awake()
    {
        Screwdriver.PickUp += ScrewdriverPickUp;
    }

    private void ScrewdriverPickUp()
    {
        _screwdriverIsReady = true;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (_screwdriverIsReady)
        {
            PickUp?.Invoke();
            Destroy(gameObject);
        }
    }

    private void OnMouseDown()
    {
        if (_screwdriverIsReady)
        {
            PickUp?.Invoke();
            Destroy(gameObject);
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log("навёлся");
    }
}