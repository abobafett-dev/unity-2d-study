using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mouse : MonoBehaviour
{
    float _velocity = 4;

    [SerializeField] private GameObject parent; 
    
    public Vector3 _startPos;
    public Vector3 _endPos;
    void Update()
    {
        // Vector3 localTarget = _endPos - parent.transform.position;
        transform.position = Vector3.MoveTowards(transform.position, _endPos, Time.deltaTime * _velocity);
    }
    
}
