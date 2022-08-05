using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class DataPersistenceManager : MonoBehaviour
{
    //this class will be a singleton class

    //
    private GameData gameData;

    private List<IDataPersistence> dataPersistenceObjects;



    public static DataPersistenceManager instance { get; private set; }

    private void Awake()
    {
        if(instance != null)
        {
            Debug.Log("Found more than one Data Persistence Manager in the Scene.");

        }
        instance = this;
    }


    private void Start()
    {
        this.dataPersistenceObjects = FindAllDataPersistenceObjects();
        LoadGame();
    }

    private void OnApplicationQuit()
    {
        SaveGame();
    }


    public void NewGame()
    {
        //initialize a new gamedata object
        this.gameData = new GameData();
    }

    public void LoadGame()
    {
        //load any saved data from a file

        //if no data can be loaed,  initizlize to a new game
        if(this.gameData == null)
        {
            Debug.Log("No Data was found. Initializing data to defaults.");
            NewGame();
        }

        //push loaded data to other scripts
        foreach (IDataPersistence dataPersistenceObj in dataPersistenceObjects)
        {
            dataPersistenceObj.LoadData(gameData);
        }

        Debug.Log("Load dead count = " + gameData.wordsFoundTotal);
    }

    public void SaveGame()
    {
        //pass the data to other scripts so they can update
        foreach (IDataPersistence dataPersistenceObj in dataPersistenceObjects)
        {
            dataPersistenceObj.SaveData(ref gameData);
        }

        Debug.Log("Saved death count = " + gameData.wordsFoundTotal);

        //save that data to a file using data handler
    }

    private List<IDataPersistence> FindAllDataPersistenceObjects()
    {
        IEnumerable<IDataPersistence> dataPersistenceObjects = FindObjectsOfType<MonoBehaviour>()
            .OfType<IDataPersistence>();

        return new List<IDataPersistence>(dataPersistenceObjects);
    }


}
