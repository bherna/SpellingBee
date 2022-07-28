using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameClassFirst : MonoBehaviour
{

    word_ClassFirst word;

    void Start()
    {
        //Get a list of words and letters


        //create an empty word
        word = new wordClassFirst();

    }


    //returns true if the word is a valid word (from the list of words)
    public bool CheckWord()
    {
        // check if the word is long enough (than three letters)
        if (word > 3) return false;

        //check if the word includes the GOLD letter
        if (word.HasGoldLetter(GoldLetter)) return false;

        //chcek if the word is an actual word (from the list)

    }

  

    
}
