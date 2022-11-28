using UnityEngine;

public class DialogFragment
{
    public GameObject Entity { get; set; }
    public string Text { get; set; }

    public DialogFragment(GameObject entity, string text)
    {
        Entity = entity;
        Text = text;
    }
}