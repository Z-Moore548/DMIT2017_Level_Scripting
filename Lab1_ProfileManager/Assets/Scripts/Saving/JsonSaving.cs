using UnityEngine;
using System.IO;

public class JSonSaving : MonoBehaviour
{
    public string filePath;
    public SaveData profileData;
    string profileName;
    GameManager gameManager;
    void Awake()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager").gameObject.GetComponent<GameManager>();
        filePath = $"SaveData/{gameManager.ProfileSelected}";
    }
    [ContextMenu("JSON Save")]

    public void SaveData(string profileName_, int score, GhostData ghostData, string color)
    {
        SaveData saveProfile = new SaveData(profileName_, score, ghostData, color);
        string file = filePath + profileName + ".json";
        string json = JsonUtility.ToJson(saveProfile, true);

        File.WriteAllText(filePath, json);
    }

    [ContextMenu("JSON Load")]

    public SaveData LoadData()
    {
        filePath = $"SaveData/{gameManager.ProfileSelected}";
        if (File.Exists(filePath))
        {
            string json = File.ReadAllText(filePath);

            profileData = JsonUtility.FromJson<SaveData>(json);
            return profileData;
        }

        else
        {
            return null;
        }
    }
}

