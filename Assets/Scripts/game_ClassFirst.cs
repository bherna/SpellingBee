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
    [SerializeField] wordBank_ClassFirst wordBank;

    //displays the players current word
    public TMP_Text playerWord_text;



    private void Start()
    {
        playerWord = GameObject.Find("game").transform.GetChild(0).gameObject.GetComponent<word_ClassFirst>();

        wordBank = GameObject.Find("game").transform.GetChild(1).gameObject.GetComponent<wordBank_ClassFirst>();

    }


    //returns true if the word is a valid word (from the list of words)
    public bool CheckWord()
    {
        // check if the word is long enough (than three letters)
        if (playerWord.wordLength() > 3) return false;

        //check if the word includes the GOLD letter
        if (playerWord.HasGoldLetter(wordBank.GoldenLetter())) return false;

        //chcek if the word is an actual word (from the list)
        return wordBank.IsWordInList(playerWord.GetWord()) ;

    }


    //button click function
    private void ButtonClick(int element)
    {
        playerWord.AddLetter(wordBank.getLetter(element));
        playerWord_text.text = playerWord.GetWord();
    }


    //button onclick events
    public void LeftTopButtonClick()
    {
        ButtonClick(1);
    }

    public void LeftBottomButtonClick()
    {
        ButtonClick(2);
    }




    public void RightTopButtonClick()
    {
        ButtonClick(3);
    }

    public void RightBottomButtonClick()
    {
        ButtonClick(4);
    }




    public void MiddleTopButtonClick()
    {
        ButtonClick(5);
    }

    public void MiddleMiddleButtonClick()
    {
        ButtonClick(0);
    }

    public void MiddleBottomButtonClick()
    {
        ButtonClick(6);
    }
  
}
