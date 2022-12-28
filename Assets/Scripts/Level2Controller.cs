using System.Linq;
using UnityEngine;

public class Level2Controller : MonoBehaviour
{
    private int _controlCount;
    private int _currentCount;
    
    // private bool isPickUp;

    private void Start()
    {
        var puddles = FindObjectsOfType<Puddle>();
        _controlCount = puddles.Length;

        Puddle.PickUp += PickUpPuddle;
        Puddle.PickDown += PickDownPuddle;
    }

    private void PickDownPuddle()
    {
        _currentCount--;
    }

    private void PickUpPuddle()
    {
        _currentCount++;
        if (_controlCount == _currentCount)
            FaderController.instance.NextScene();
    }
}