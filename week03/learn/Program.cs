using System;

public class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("\n======================\nDuplicate Counter\n======================");
        DuplicateCounter.Run();

        Console.WriteLine("\n======================\nTranslator\n======================");
        Translator.Run();
    }
}

// W03 Learning Activity: Articulating Answers to Technical Questions
// Consider the following scenario:

// Write code to find the first time in a string when a letter is duplicated.

// Answer each of the following:

// What are possible scenarios to consider? (For example, think of a few strings that you would want to try with your solution.)
// What are some data structures that may be useful? And what would their performance be?
// What are the boundary conditions that you should consider for this problem?
// Outline a possible solution.


/*string[] listOfWords = {"Cat", "Dog", "Pneumoltramicroscopicsilicvulcanicniosys"};
foreach (var word in listOfWords)
{
    string wordToPrintTemp = "";
    HashSet<char> _word = new HashSet<char>();
    foreach (var letter in word)
    {
        wordToPrintTemp += letter;
        if (!_word.Contains(letter))
        {
            _word.Add(letter);
            if (word.Count() == _word.Count())
            {
                System.Console.WriteLine($"No duplicates in the word {wordToPrintTemp}");
            }
        }
        else
        {
            System.Console.WriteLine($"The letter {letter} repeates for the first time here -> {wordToPrintTemp}");
        }
    }
}*/