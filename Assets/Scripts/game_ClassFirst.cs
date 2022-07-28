using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class game_ClassFirst : MonoBehaviour
{

    //holds the player's word
    word_ClassFirst playerWord = new word_ClassFirst(null);

    //holds the game's usable letters and words
    wordList_ClassFirst wordList = new wordList_ClassFirst();

    

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

  
}
