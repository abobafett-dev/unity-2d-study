using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _defaultScaleX;
    [SerializeField] private Canvas _canvas;
    
    private void Start()
    {
        _defaultScaleX = transform.localScale.x;
        Mouse.Show += ShowButton;
    }

    private void ShowButton(bool value)
    {
        _canvas.gameObject.SetActive(value);
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