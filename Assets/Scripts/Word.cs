using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Word
{
    public string Text { get; protected set; }

    public Word(string text)
    {
        Text = text;
    }

    public abstract void OnWordComplete(Typer typer);
}

