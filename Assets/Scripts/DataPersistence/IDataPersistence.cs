using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDataPersistence
{
    //this class will describe the methods it will have



    //this reads in a game data object
    void LoadData(GameData data);


    //this modifies the given gamedata object
    void SaveData(ref GameData data);
}
