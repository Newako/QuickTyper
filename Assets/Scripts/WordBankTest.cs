using NUnit.Framework;
using UnityEngine.TestTools;
using System.Collections.Generic;
using UnityEngine.Assertions;

public class WordBankTests
{
    public void GetWord_ReturnsWord()
    {
        // Arrange
        WordBank wordBank = new WordBank();
        wordBank.GenerateWordList();

        // Act
        Word word = wordBank.GetWord();

        // Assert
        Assert.IsNotNull(word);
        Assert.IsInstanceOf<Word>(word);
        Assert.IsFalse(string.IsNullOrEmpty(word.Text));
    }


    public void AllWords_AreLowercase()
    {
        WordBank wordBank = new WordBank();
        wordBank.GenerateWordList();

        foreach (var word in wordBank.wordList)
        {
            Assert.AreEqual(word.Text, word.Text.ToLower());
        }
    }
}
