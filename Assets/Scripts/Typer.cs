using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Typer : MonoBehaviour
{
    public WordBank wordBank = null;
    public TMP_Text wordOutput = null;
    public TMP_Text scoreOutput = null;
    public HealthBar healthBar = null;

    private string remainingWord = string.Empty;
    private Word currentWord = null;
    private int score = 0;

    private void Start()
    {
        score = 0;
        UpdateScoreDisplay();
        SetCurrentWord();
    }

    private void SetCurrentWord()
    {
        currentWord = wordBank.GetWord();
        SetRemainingWord(currentWord.Text);
    }

    private void SetRemainingWord(string newString)
    {
        remainingWord = newString;
        wordOutput.text = remainingWord;
    }

    private void Update()
    {
        if (healthBar != null && healthBar.GetCurrentHealth() > 0f)
        {
            CheckInput();
        }
    }

    private void CheckInput()
    {
        if (Input.anyKeyDown)
        {
            string keysPressed = Input.inputString;

            if (keysPressed.Length == 1)
                EnterLetter(keysPressed);
        }
    }

    private void EnterLetter(string typedLetter)
    {
        if (IsCorrectLetter(typedLetter))
        {
            RemoveLetter();

            if (IsWordComplete())
            {
                currentWord.OnWordComplete(this);
                SetCurrentWord();
            }
        }
    }

    private bool IsCorrectLetter(string letter)
    {
        return remainingWord.IndexOf(letter) == 0;
    }

    private void RemoveLetter()
    {
        string newString = remainingWord.Remove(0, 1);
        SetRemainingWord(newString);
    }

    private bool IsWordComplete()
    {
        return remainingWord.Length == 0;
    }

    public void AddPoints(int points)
    {
        score += points;
        UpdateScoreDisplay();
    }

    public void DecreaseHealth(float amount)
    {
        if (healthBar != null)
            healthBar.ModifyHealth(-amount);
    }

    private void UpdateScoreDisplay()
    {
        if (scoreOutput != null)
            scoreOutput.text = "Score: " + score.ToString();
    }
}
