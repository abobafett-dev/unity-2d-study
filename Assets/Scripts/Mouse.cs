using UnityEngine;

public class Mouse : CanvasShow
{
    public delegate void TriggerEvent();

    public static event TriggerEvent PickUp;

    private Rigidbody2D _rigidbody2D;

    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        NextVelocity();
    }

    private void Update()
    {
        if (isTrigger && Input.GetKeyDown(KeyCode.F))
        {
            PickUp?.Invoke();
            Destroy(gameObject);
        }
    }

    private void NextVelocity()
    {
        var x = Random.Range(-1f, 1f);
        var y = Random.Range(-1f, 1f);

        if (x > 0)
            transform.rotation = new Quaternion(0, 180, 0, 0);
        else
            transform.rotation = new Quaternion(0, 0, 0, 0);


        _rigidbody2D.velocity = new Vector2(x, y) * 5;
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        NextVelocity();
    }
}