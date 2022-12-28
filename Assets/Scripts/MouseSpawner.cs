using UnityEngine;

public class MouseSpawner : MonoBehaviour
{
    // Start is called before the first frame update

    public int _count = 1;

    private void Start()
    {
        var mouse = Resources.Load<Mouse>("Mouse");
        for (var i = 0; i < _count; i++)
        {
            Instantiate(mouse, transform.position, Quaternion.identity);
        }
    }
}