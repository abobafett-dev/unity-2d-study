using UnityEngine;

public class Lid : MonoBehaviour
{
    private int _boltCount;

    private Rigidbody2D _rigidbody2D;

    void Start()
    {
        Bolt.PickUp += BoltClick;
    }

    private void BoltClick()
    {
        _boltCount++;
    }

    void Update()
    {
        if (_boltCount == 4)
        {
            _rigidbody2D = gameObject.AddComponent<Rigidbody2D>();
            _rigidbody2D.gravityScale = 1;
            _boltCount = 0;
        }
    }
}