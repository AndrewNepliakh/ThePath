using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;

public static class SaveManager 
{
    public static void Save()
    {
        var saveDataPath = Application.persistentDataPath + "/SaveData.json"; ;
        
        var saveData = new SaveData()
        {
            UserData = UserManager.User.UserData
        };

        var json = JsonConvert.SerializeObject(saveData);

        if (!File.Exists(saveDataPath))
        {
            var file = File.Create(saveDataPath);
            file.Close();
        }

        File.WriteAllText(saveDataPath, json);
    }

    public static SaveData Load()
    {
        var saveDataPath = Application.persistentDataPath + "/SaveData.json"; ;
        
        if (File.Exists(saveDataPath))
        {
            var json = File.ReadAllText(saveDataPath);
            return JsonConvert.DeserializeObject<SaveData>(json);
        }

        return new SaveData() { };
    }
}