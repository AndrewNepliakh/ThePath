using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class GameEnterPoint : MonoBehaviour
{
    private void Awake()
    {
        var saveData = SaveManager.Load();
        UserManager.Init(saveData.UserData);
        
        Debug.Log(UserManager.CurrentUser.Character.Stats.NickName);
        Debug.Log(UserManager.CurrentUser.ID);
    }

    private void OnApplicationQuit()
    {
        SaveManager.Save();
    }
    
}
