using UnityEngine;

public class GameEnterPoint : MonoBehaviour
{
    private void Awake()
    {
        var saveData = SaveManager.Load();
        UserManager.Init(saveData.UserData);
        
        
    }

    private void OnApplicationQuit()
    {
        SaveManager.Save();
    }
}