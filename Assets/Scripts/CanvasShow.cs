using UnityEngine;

public class CanvasShow : MonoBehaviour
{
    
    public delegate void ShowEvent(bool value);
    public static event ShowEvent Show;
    
    protected bool isTrigger = false;
    
    protected void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag.Equals("Player"))
        {
            Show?.Invoke(true);
            isTrigger = true;
        }
    }

    protected void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag.Equals("Player"))
        {
            Show?.Invoke(false);
            isTrigger = false;
        }
    }
}
