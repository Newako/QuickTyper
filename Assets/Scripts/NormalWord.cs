using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalWord : Word
{
    public NormalWord(string text) : base(text) { }

    public override void OnWordComplete(Typer typer)
    {
        typer.AddPoints(1);
    }
}

