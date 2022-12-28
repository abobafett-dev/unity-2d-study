using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Wire : MonoBehaviour, IPointerDownHandler
{
    public delegate void TriggerEvent(int num);

    public static event TriggerEvent PickUp;

    [SerializeField] private int num;

    public void OnPointerDown(PointerEventData eventData)
    {
        
        gameObject.SetActive(false);
        PickUp?.Invoke(num);
    }
}