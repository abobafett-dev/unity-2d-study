using UnityEngine;

public class Bonus : CanvasShow
{
    private void Update()
    {
        if (isTrigger && Input.GetKeyDown(KeyCode.F))
        {
            FaderController.instance._playerSpeed += 1;
            Destroy(gameObject);
        }
    }
}