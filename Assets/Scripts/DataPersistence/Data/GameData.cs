using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[System.Serializable]
public class GameData
{
    //saves the number of words the player has found total
    public int wordsFoundTotal;


    //constructor defined with default values
    //game starts (constructor) when no data to load
    public GameData()
    {
        this.wordsFoundTotal = 0;
    }


}
