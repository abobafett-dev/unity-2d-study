using System.Linq;
using UnityEngine;

public class Level0Controller : MonoBehaviour
{
    private int _controlCount;
    private int _currentCount;

    private void Start()
    {
        var spawners = FindObjectsOfType<MouseSpawner>();
        _controlCount = spawners.Sum(x => x._count);

        Mouse.PickUp += PickUpMouse;
    }

    private void PickUpMouse()
    {
        _currentCount++;
        if (_controlCount == _currentCount)
            FaderController.instance.NextScene();
    }
}