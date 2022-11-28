using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class TriggerObject : MonoBehaviour
{

    private Rigidbody2D _rigidbody2D;
    private BoxCollider2D _boxCollider2D;

    private bool isTrigger = false;
    
    private void Start()
    {
        _boxCollider2D = GetComponent<BoxCollider2D>();
        _boxCollider2D.isTrigger = true;
    }

    private void Update()
    {
        if(isTrigger && Input.GetKeyDown(KeyCode.F))
            Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log("Зашёл");
        isTrigger = true;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        Debug.Log("Вышел");
        isTrigger = false;
    }
}
