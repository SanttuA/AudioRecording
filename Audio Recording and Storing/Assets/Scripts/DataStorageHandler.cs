using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class DataStorageHandler<TDataType>
{	
    //Saves data to application persistent data path with given file name.
    public void SaveData(TDataType data, string fileName)
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/" + fileName);
        bf.Serialize(file, data);
        file.Close();
    }

    //Loads and returns data from application persistent data path with given file name.
    //If data doesn't exist, default data value will be returned
    public TDataType LoadData(string fileName)
    {
        if(File.Exists(Application.persistentDataPath + "/" + fileName))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/" + fileName, FileMode.Open);
            TDataType data = (TDataType)bf.Deserialize(file);
            file.Close();

            return data;
        }

        Debug.Log("File called: " + Application.persistentDataPath + "/" + fileName + " does not exist!");
        return default(TDataType);
    }
}
