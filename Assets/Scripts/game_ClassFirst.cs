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


    //button text
    [SerializeField]
    public TMP_Text m_m;
    public TMP_Text l_t;
    public TMP_Text l_b;
    public TMP_Text r_t;
    public TMP_Text r_b;
    public TMP_Text m_t;
    public TMP_Text m_b;


    private void Start()
    {

        //attach objects to be used
        playerWord = GameObject.Find("Game").transform.GetChild(0).gameObject.GetComponent<word_ClassFirst>();

        wordBank = GameObject.Find("Game").transform.GetChild(1).gameObject.GetComponent<wordBank_ClassFirst>();


        //update player word text
        playerWord_text.text = "";

        //update button text
        UpdateButtonsText();
  
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


    private void UpdateButtonsText()
    {
        /*

        [0] = middlemiddle (gold)

        [1] = lefttop
        [2] = leftbottom

        [3] = righttop
        [4] = rightbottom

        [5] = middletop
        [6] = middlebottom


        */
        m_m.text = wordBank.getLetter(0).ToString();
        l_t.text = wordBank.getLetter(1).ToString();
        l_b.text = wordBank.getLetter(2).ToString();
        r_t.text = wordBank.getLetter(3).ToString();
        r_b.text = wordBank.getLetter(4).ToString();
        m_t.text = wordBank.getLetter(5).ToString();
        m_b.text = wordBank.getLetter(6).ToString();
    }



    //button click function 
    private void ButtonClick(int element)
    {
        playerWord.AddLetter(wordBank.getLetter(element));
        playerWord_text.text = playerWord.GetWord();
    }

    public void DeletePlayerChar()
    {
        //remove last letter
        playerWord.DelLetter();

        //update text
        playerWord_text.text = playerWord.GetWord();
    }

    public void ShuffleLetters()
    {
        //shuffle list
        wordBank.Shuffle();

        //update buttons text
        UpdateButtonsText();
    }


    ////button onclick events

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
