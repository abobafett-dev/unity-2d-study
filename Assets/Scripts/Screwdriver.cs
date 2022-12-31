using UnityEngine;

public class Screwdriver : CanvasShow
{
    public delegate void TriggerEvent();

    public static event TriggerEvent PickUp;

    private void Update()
    {
        if (isTrigger && Input.GetKeyDown(KeyCode.F))
        {
            PickUp?.Invoke();
            Destroy(gameObject);
        }
    }
}