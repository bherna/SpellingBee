using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class DataPersistenceManager : MonoBehaviour
{
    //this class will be a singleton class


    [Header("File Storage Config")]
    [SerializeField] private string fileName;



    //
    private GameData gameData;

    private List<IDataPersistence> dataPersistenceObjects;

    private FileDataHandler dataHandler;

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
        //for reading and writing to file
        this.dataHandler = new FileDataHandler(Application.persistentDataPath, fileName);

        //for loading in objects into the game
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
        this.gameData = dataHandler.Load();

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

    }

    public void SaveGame()
    {
        //pass the data to other scripts so they can update
        foreach (IDataPersistence dataPersistenceObj in dataPersistenceObjects)
        {
            dataPersistenceObj.SaveData(ref gameData);
        }


        //save that data to a file using data handler
        dataHandler.Save(gameData);
    }

    private List<IDataPersistence> FindAllDataPersistenceObjects()
    {
        IEnumerable<IDataPersistence> dataPersistenceObjects = FindObjectsOfType<MonoBehaviour>()
            .OfType<IDataPersistence>();

        return new List<IDataPersistence>(dataPersistenceObjects);
    }


}
