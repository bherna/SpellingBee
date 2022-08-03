using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//text mesh pro
using TMPro;
using System;

public class game_ClassFirst : MonoBehaviour
{


    //============variables===========================

    //holds the player's word
    [SerializeField] word_ClassFirst playerWord;

    //holds the game's usable letters and words
    [SerializeField] wordList_ClassFirst wordList;

    //displays the players current word
    public TMP_Text playerWord_text;

    private void Start()
    {

        //============variables===========================

        //holds the player's word
        playerWord = gameObject.AddComponent<word_ClassFirst>();

        //holds the game's usable letters and words
        wordList = gameObject.AddComponent<wordList_ClassFirst>();


    }


    //returns true if the word is a valid word (from the list of words)
    public bool CheckWord()
    {
        // check if the word is long enough (than three letters)
        if (playerWord.wordLength() > 3) return false;

        //check if the word includes the GOLD letter
        if (playerWord.HasGoldLetter(wordList.GoldenLetter())) return false;

        //chcek if the word is an actual word (from the list)
        return wordList.IsWordInList(playerWord);

    }



    //button onclick events
    public void LeftTopButtonClick()
    {
        playerWord.AddLetter(wordList.getLetter(1));
        Debug.Log(playerWord.GetWord());
    }

    public void LeftBottomButtonClick()
    {
        playerWord.AddLetter(wordList.getLetter(2));
    }




    public void RightTopButtonClick()
    {
        playerWord.AddLetter(wordList.getLetter(3));
    }

    public void RightBottomButtonClick()
    {
        playerWord.AddLetter(wordList.getLetter(4));
    }




    public void MiddleTopButtonClick()
    {
        playerWord.AddLetter(wordList.getLetter(5));
    }

    public void MiddleMiddleButtonClick()
    {
        playerWord.AddLetter(wordList.GoldenLetter());
    }

    public void MiddleBottomButtonClick()
    {
        playerWord.AddLetter(wordList.getLetter(6));
    }
  
}
