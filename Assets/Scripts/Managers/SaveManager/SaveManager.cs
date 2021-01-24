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
            UserData = new UserData{LastUser = UserManager.CurrentUser, Users = UserManager.Users},
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
            SaveData saveData;
            try
            {
                saveData = JsonConvert.DeserializeObject<SaveData>(json);
            }
            catch (Exception e)
            {
                saveData = GetDefaultSaveData();
            }
           
            return saveData;
        }

        return GetDefaultSaveData();
    }

    private static SaveData GetDefaultSaveData()
    {
        var lastUser = new User();
        return new SaveData
        {
            UserData = new UserData{LastUser = lastUser, Users = new List<User>{lastUser}},
        };
    }
}