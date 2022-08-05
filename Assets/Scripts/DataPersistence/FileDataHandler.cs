using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;


public class FileDataHandler
{
    //directory to save to
    private string dataDirPath = "";

    //data file we want to save to
    private string dataFileName = "";

    private bool useEncryption = false;

    private readonly string encryptionCodeWord = "word";

    public FileDataHandler(string dataDirPath, string dataFileName, bool useEncryption)
    {
        this.dataDirPath = dataDirPath;
        this.dataFileName = dataFileName;
        this.useEncryption = useEncryption;
    }

    public GameData Load()
    {
        //use Path.Combine to account for different OS's with differnt path seperators
        string fullPath = Path.Combine(dataDirPath, dataFileName);

        //game we are going to load into
        GameData loadedData = null;

        //make sure the file exsits
        //then load in the file
        if (File.Exists(fullPath))
        {
            try
            {
                //load the serialized data from the file
                string dataToLoad = "";
                using (FileStream stream = new FileStream(fullPath, FileMode.Open))
                {
                    using (StreamReader reader = new StreamReader(stream))
                    {
                        dataToLoad = reader.ReadToEnd();
                    }
                }

                //the optional decrypt step
                if (useEncryption)
                {
                    dataToLoad = EncryptDecrypt(dataToLoad);
                }


                //now deserialize the data from Json back into C# object
                loadedData = JsonUtility.FromJson<GameData>(dataToLoad);

            }
            catch (Exception e)
            {
                Debug.LogError("Error occured when trying to load data from File: " + fullPath + "\n" + e);
            }
        }

        //reuturn
        return loadedData;

    }

    public void Save(GameData data)
    {
        //use Path.Combine to account for different OS's with differnt path seperators
        string fullPath = Path.Combine(dataDirPath, dataFileName);


        try
        {
            //create the directory path, just incase it doesnt exisit
            Directory.CreateDirectory(Path.GetDirectoryName(fullPath));

            //serialize the C# game data object into json
            string dataToStore = JsonUtility.ToJson(data, true);


            //the optional encrypt data step
            if (useEncryption)
            {
                dataToStore = EncryptDecrypt(dataToStore);
            }

            //write the serialized data to the file
            //using method makes sures we close the file after we are done
            using (FileStream stream = new FileStream(fullPath, FileMode.Create))
            {
                using (StreamWriter writer = new StreamWriter(stream))
                {
                    writer.Write(dataToStore);
                }
            }

        }
        catch (Exception e)
        {
            Debug.LogError("Error occured when trying to save data to file: " + fullPath + "\n" + e);
        }

    }


    // 'simple' implementaion of XOR encryption
    private string EncryptDecrypt(string data)
    {
        string modifiedData = "";
        for (int i = 0; i < data.Length; i++)
        {
            modifiedData += (char)(data[i] ^ encryptionCodeWord[i % encryptionCodeWord.Length]);
        }
        return modifiedData;
    }

}
