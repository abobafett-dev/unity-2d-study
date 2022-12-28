using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LidCreateTrigger : CanvasShow
{
    [SerializeField] private Canvas _canvas;
    [SerializeField] private Canvas _canvasDva;
    
    private void Update()
    {
        if (isTrigger && Input.GetKeyDown(KeyCode.F))
        {
            _canvas.enabled = true;
            _canvasDva.gameObject.SetActive(false);
        }
    }
}
