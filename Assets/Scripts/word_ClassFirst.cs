using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class word_ClassFirst : MonoBehaviour
{


    //empty word 
    private List<char> word;

    private void Start()
    {

        word = new List<char>();
    }

    

    private void SetWord(string newWord)
    {
        foreach(char letter in newWord){

            word.Add(letter);
        }
    }

    //get/return the word of the player
    public string GetWord()
    {
        string str = string.Join("", word);
        return str;
    }

    //will add a letter at the end of a word
    public void AddLetter(char letter)
    {
        word.Add(letter);
    }

    public int wordLength()
    {
        return word.Count;
    }


    //will remove the last letter of a word only
    public void DelLetter()
    {
        word.RemoveAt(-1);
    }


    //checks if the word currently has the gold letter
    public bool HasGoldLetter(char goldLetter)
    {
        return word.Contains(goldLetter);
    }
    
}
