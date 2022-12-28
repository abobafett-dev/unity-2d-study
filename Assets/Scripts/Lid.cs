using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lid : MonoBehaviour
{

    private int _boltCount;

    private Rigidbody2D _rigidbody2D;
    
    void Start()
    {
        Bolt.PickUp += BoltClick;
        // _rigidbody2D = GetComponent<Rigidbody2D>();
        
    }

    private void BoltClick()
    {
        _boltCount++;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (_boltCount == 4)
        {
            _rigidbody2D = gameObject.AddComponent<Rigidbody2D>();
            _rigidbody2D.gravityScale = 1;
            _boltCount = 0;
        }
        else
        {
            // transform.position = new Vector3(-85, 0, 0);
        }
    }
}
