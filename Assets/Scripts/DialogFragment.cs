using System;
using UnityEngine;

public class DialogFragment
{
    public GameObject Entity { get; set; }
    public string Text { get; set; }
    public Action Action { get; set; }

    public DialogFragment(GameObject entity, string text)
    {
        Entity = entity;
        Text = text;
    }
    
    public DialogFragment(GameObject entity, string text, Action action)
    {
        Entity = entity;
        Text = text;
        Action = action;
    }
}