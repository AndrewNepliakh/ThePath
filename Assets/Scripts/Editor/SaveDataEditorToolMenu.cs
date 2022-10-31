using System.IO;
using UnityEditor;
using UnityEngine;

public class SaveDataEditorToolMenu
{
    private const string OpenSaveFileMenu = "Tools/Open Save File Directory";
    private const string DeleteSaveFileMenu = "Tools/Delete Save File Directory";
    
    [MenuItem(OpenSaveFileMenu)]
    private static void OpenSaveFileLocation()
    {
#if UNITY_EDITOR_WIN
        if (Directory.Exists(Application.persistentDataPath))
            System.Diagnostics.Process.Start(Application.persistentDataPath);
#endif
    }
    
    [MenuItem(DeleteSaveFileMenu)]
    private static void DeleteSaveFileLocation()
    {
        if (Directory.Exists(Application.persistentDataPath))
        {
            foreach (var directory in Directory.GetDirectories(Application.persistentDataPath))
            {
                DirectoryInfo dir = new DirectoryInfo(directory);
                dir.Delete(true);
            }
     
            foreach (var file in Directory.GetFiles(Application.persistentDataPath))
            {
                FileInfo fileInfo = new FileInfo(file);
                fileInfo.Delete();
            }
        }
    }
}
