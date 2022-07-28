using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class word_ClassFirst : MonoBehaviour
{


    //empty word 
    private List<char> word;



    public word_ClassFirst(string newWord)
    {
        //if we dont want a set word, just set newWord to null
        if (newWord.Length > 0) SetWord(newWord);
    }

    private void SetWord(string newWord)
    {
        foreach(char letter in newWord){

            word.Add(letter);
        }
    }

    //will add a letter at the end of a word
    public void AddLetter(char letter)
    {
        word.Add(letter);
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
