using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wordBank_ClassFirst : MonoBehaviour
{

    //hold every word possible for this game
    private List<string> wordBank;

    //hold a list of the letters to be used from this word bank
    //golden letter is the first element, always
    //letter order follows:
    /*
      
     
     [0] = middlemiddle (gold)

     [1] = lefttop
     [2] = leftbottom

     [3] = righttop
     [4] = rightbottom

     [5] = middletop
     [6] = middlebottom
     
     
     */
    private List<char> letteresList;


    private void Start()
    {

        wordBank = new List<string>();
        letteresList = new List<char>();

        //enter every letter use in this game
        letteresList.Add('u');  
        letteresList.Add('a');
        letteresList.Add('l');
        letteresList.Add('n');
        letteresList.Add('r');
        letteresList.Add('t');
        letteresList.Add('y');

        //enter every word into the word bank
        wordBank.Add("lulu");
        wordBank.Add("yurt");
        ///...
    }

    //golden letter is the first element of the list always
    public char GoldenLetter()
    {
        return letteresList[0];
    }

    public char getLetter(int element)
    {
        return letteresList[element];
    }

    //checks if the word given is in contained in the word bank
    public bool IsWordInList(string word)
    {
        if (wordBank.Contains(word)) return true;
        else return false;
        
    }

    public void Shuffle()
    {

        //create a temperary list
        List<char> temp = new List<char>();

        //random temp int
        int element = 0;

        //first element needs to be the golden letter
        temp.Add(letteresList[0]);
        letteresList.RemoveAt(0);

        for(int i = 0; i < 6; i++)
        {
            //update random number within list range
            element = Random.Range(0, letteresList.Count);

            //add to new list and remove
            temp.Add(letteresList[element]);
            letteresList.RemoveAt(element);

        }

        //update letterlist with new shuffled list
        letteresList = temp;
    }


    





}
