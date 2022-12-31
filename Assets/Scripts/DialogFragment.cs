using System;
using TMPro;
using UnityEngine;

public class DialogFragment
{
    public GameObject Entity { get; set; }
    public string Text { get; set; }
    public Action Action { get; set; }
    public FontStyles Style { get; set; }

    public DialogFragment(GameObject entity, string text)
    {
        Entity = entity;
        Text = text;
        Style = FontStyles.Normal;
    }

    public DialogFragment(GameObject entity, string text, FontStyles style)
    {
        Entity = entity;
        Text = text;
        Style = style;
    }

    public DialogFragment(GameObject entity, string text, Action action)
    {
        Entity = entity;
        Text = text;
        Action = action;
    }
}