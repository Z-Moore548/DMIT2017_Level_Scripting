using UnityEngine;
using System.IO;
using Unity.Android.Gradle.Manifest;

public class JSonSaving : MonoBehaviour
{
    public string filePath;
    public SaveData profileData;
    string profileName;
    [ContextMenu("JSON Save")]

    public void SaveData(string profileName_, int score, GhostData ghostData)
    {
        SaveData saveProfile = new SaveData(profileName_, score, ghostData);
        string file = filePath + profileName + ".json";
        string json = JsonUtility.ToJson(saveProfile, true);

        File.WriteAllText(filePath, json);
    }

    [ContextMenu("JSON Load")]

    public void LoadData()
    {
        if (File.Exists(filePath))
        {
            string json = File.ReadAllText(filePath);

            profileData = JsonUtility.FromJson<SaveData>(json);
        }

        else
        {
            Debug.LogError("Save file not found");
        }
    }
}

