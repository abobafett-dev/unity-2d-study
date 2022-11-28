using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _defaultScaleX;
    
    private void Start()
    {
        _defaultScaleX = transform.localScale.x;
    }

    private void FixedUpdate()
    {
        transform.Translate(Input.GetAxis("Horizontal") * _speed * Time.deltaTime,
            Input.GetAxis("Vertical") * _speed * Time.deltaTime, 0f);
        
        var scale = transform.localScale;
        
        if (Input.GetAxis("Horizontal") < 0)
            scale.x = _defaultScaleX;
        else
            scale.x = -_defaultScaleX;

        transform.localScale = scale;
    }
}