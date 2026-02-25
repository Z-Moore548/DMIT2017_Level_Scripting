using System.IO;
using UnityEngine;

public class Saving : MonoBehaviour
{
    public static Saving Instance;
    public string filePath;
    public GameState profileData;
    string profileName;
    public GameStateManager gameManager;
    void Awake()
    {
        Instance = this;
        
        filePath = "Assets/Resources/SaveData/SaveGame.json";
    }
    void Start()
    {
        gameManager = GameStateManager.Instance;
    }
    [ContextMenu("JSON Save")]

    public void SaveData(GameState state)
    {
        GameState saveProfile = gameManager.gameState;
        string json = JsonUtility.ToJson(saveProfile, true);

        File.WriteAllText(filePath, json);
    }

    [ContextMenu("JSON Load")]

    public GameState LoadData()
    {
        
        if (File.Exists(filePath))
        {
            string json = File.ReadAllText(filePath);

            profileData = JsonUtility.FromJson<GameState>(json);
            return profileData;
        }

        else
        {
            return null;
        }
    }

    public void DeleteFile()
    {
        File.Delete(filePath);
        File.Delete($"{filePath}.meta");
    }
}
