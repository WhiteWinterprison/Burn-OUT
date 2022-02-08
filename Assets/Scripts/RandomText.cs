using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;




public class RandomText : MonoBehaviour
{

    public string[] words = { "Quote1", "Quote2", "Quote3" };
    
    public Text quote;

    private void Start()
    {
        // log whatever comes out of the RandomWord string.
        string wordToDisplay = RandomWord();

        quote.text = wordToDisplay;
    }

    // when you see a string function,
    // it will return a string that
    // you can use anywhere!
    private string RandomWord()
    {
        // grab a random string from the words array
        string randomWord = words[Random.Range(0, words.Length)];

        // return it (this will be the string that the script will use)
        return randomWord;
    }
}