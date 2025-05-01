using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusWord : Word
{
    public BonusWord(string text) : base(text) { }

    public override void OnWordComplete(Typer typer)
    {
        typer.AddPoints(5);
    }
}

