using System.Linq;
using System.Collections.Generic;
using UnityEngine;

public class WordBank : MonoBehaviour
{

    private List<Word> wordList = new List<Word>();
    private int currentIndex = 0;

    private void Start()
    {
        GenerateWordList();
        Shuffle(wordList);

    }

    private void GenerateWordList()
    {
        string[] baseWords = { "category", "property", "addition", "length", "hearing", "health", "director", "idea", "language", "coffee", "ratio", "application", "relationship", "marriage", "establishment",
         "reaction", "agreement", "shopping", "difficulty", "reception", "organization" };

        foreach (string word in baseWords)
        {

            int roll = Random.Range(0, 100);

            if (roll < 60)
                wordList.Add(new NormalWord(word));
            else if (roll < 85)
                wordList.Add(new BonusWord(word));
        }
    }

    private void Shuffle(List<Word> list)
    {
        for (int i = 0; i < list.Count; i++)
        {
            int random = Random.Range(i, list.Count);
            Word temp = list[i];
            list[i] = list[random];
            list[random] = temp;
        }
    }

    public Word GetWord()
    {
        if (wordList.Count == 0)
        {
            GenerateWordList();
            Shuffle(wordList);
            currentIndex = 0;
        }

        if (currentIndex >= wordList.Count)
        {
            Shuffle(wordList);
            currentIndex = 0;
        }

        return wordList[currentIndex++];
    }

}