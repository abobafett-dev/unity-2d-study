using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Level1Controller : MonoBehaviour
{
    [SerializeField] private List<GameObject> _cards;
    [SerializeField] private List<GameObject> _wires;
    
    // private int _controlCount;
    private int _currentIndex;

    private List<int> _usedIndex;

    public delegate void TriggerEvent();

    public static event TriggerEvent Sta;
    
    private void Start()
    {
        var countSpawned = 0;

        _usedIndex = new List<int>();
        
        for (var i = 0; countSpawned < 3; i++)
        {
            var index = Random.Range(0, _cards.Count);
            if (!_usedIndex.Contains(index))
            {
                _usedIndex.Add(index);
                _cards[index].GetComponent<SpriteRenderer>().enabled = true;
                countSpawned++;
                Debug.Log(index);
            }
            
        }

        Wire.PickUp += ClickWire;
    }

    private void ClickWire(int num)
    {
        if (_usedIndex[_currentIndex] != num)
        {
            RemoveMiniGame();
            Debug.Log("Неправильно");
            return;
        }

        Debug.Log("Зоябумба");
        _currentIndex++;
        if (_currentIndex == 3)
            FaderController.instance.NextScene();
    }

    private void RemoveMiniGame()
    {
        foreach (var wire in _wires)
        {
            wire.SetActive(true);
        }

        _currentIndex = 0;
    }
}