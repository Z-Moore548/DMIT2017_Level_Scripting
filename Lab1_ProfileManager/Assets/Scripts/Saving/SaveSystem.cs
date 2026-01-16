using UnityEngine;
using System.IO;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

public class SaveSystem : MonoBehaviour
{
    public string filePath;
    public List<SaveData> saveDataList = new List<SaveData>();
    void Start()
    {
        //CreateSave("Sujan", 1000);
        Debug.Log(LoadData("Sujan"));
    }
    
    public void CreateSave(string profile, int score)
    {
        SaveData saveData = new SaveData(profile, score);
        bool fileExists = File.Exists(filePath);

        using(StreamWriter writer = new StreamWriter(filePath, true))
        {
            if (!fileExists)
            {
                writer.WriteLine("Profile Name, Score");
            }

            writer.WriteLine($"{saveData.profileName}, {saveData.highScore}");
            saveDataList.Add(saveData);
        }
    }
    public void UpdateScore(SaveData saveData_)
    {
        
    }
    public void DeleteSave(SaveData saveData_)
    {
        
    }
    public int LoadData(string profileName_)
    {
        int highScore = 0;
        string[] lines = File.ReadAllLines(filePath);
        for (int i = 0; i < lines.Length; i++)
        {
            string[] columns = Regex.Split(lines[i], ",(?=(?:[^\"]*\"[^\"]*\")*[^\"]*$)");
            if(columns[0] == profileName_)
            {
                highScore = int.Parse(columns[1]);
                break;
            }
        }
        SaveData saveData = new SaveData(profileName_, highScore);
        saveDataList.Add(saveData);
        return highScore;
    }
}
[Serializable]
public class SaveData
{
    public string profileName;
    public int highScore;
    public SaveData(string profile, int score)
    {
        profileName = profile;
        highScore = score;
    }
}
