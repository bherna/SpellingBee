using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wordClassFirst : MonoBehaviour
{


    //empty word 
    private List<char> word;



    // Start is called before the first frame update
    void Start()
    {
        //instant the new word as an empty list
        word = new List<char>();
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

    
}
