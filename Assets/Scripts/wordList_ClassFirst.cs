using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wordList_ClassFirst : MonoBehaviour
{

    //hold every word possible for this game
    private List<word_ClassFirst> wordBank = new List<word_ClassFirst>();

    //hold a list of the letters to be used from this word bank
    //golden letter is the first element, always
    private List<char> letteresList = new List<char>();


    private void Start()
    {

        //enter every letter use in this game
        letteresList.Add('u');
        letteresList.Add('a');
        letteresList.Add('l');
        letteresList.Add('n');
        letteresList.Add('r');
        letteresList.Add('t');
        letteresList.Add('y');

        //enter every word into the word bank
        wordBank.Add(new word_ClassFirst("lulu"));
        wordBank.Add(new word_ClassFirst("yurt"));
        ///...
    }

    //golden letter is the first element of the list always
    public char GoldenLetter()
    {
        return letteresList[0];
    }

    //checks if the word given is in contained in the word bank
    public bool IsWordInList(word_ClassFirst word)
    {
        if (wordBank.Contains(word)) return true;
        else return false;
        
    }




    





}
