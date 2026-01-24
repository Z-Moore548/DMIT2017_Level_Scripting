using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class MenuController : MonoBehaviour
{
    GameManager gameManager;
    public TMP_InputField text;
    public GameObject confim, saveCheck;
    public GhostDataRecorder recorder;
    public TMP_Dropdown dropdown;
    public TMP_Text textbox;
    public SaveData save;
    public JSonSaving saving;
    void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager").gameObject.GetComponent<GameManager>();
        saving = GameObject.FindGameObjectWithTag("Saving").gameObject.GetComponent<JSonSaving>();
        if(SceneManager.GetActiveScene().name != "MainMenu")
        {
            recorder = GameObject.FindGameObjectWithTag("Player").gameObject.GetComponentInParent<GhostDataRecorder>();
        }
        
    }
    public void StartGame()
    {
        SceneManager.LoadScene("SampleScene");
    }
    public void Quit()
    {
        Application.Quit();
       
    }
    public void MaybeDelete()
    {
        confim.SetActive(true);
    }
    public void Delete()
    {
        File.Delete($"Assets/Resources/{gameManager.ProfileSelected}");
        File.Delete($"Assets/Resources/{gameManager.ProfileSelected}.meta");
        confim.SetActive(false);
    }
    public void NoDelete()
    {
        confim.SetActive(false);
    }
    public void TextField()
    {
        gameManager.ProfileSelected = text.text;
    }
    public void Dropdown()
    {
        if(dropdown.value == 0)
        {
            gameManager.CarSelected = "Gray";
        }
        else if (dropdown.value == 1)
        {
            gameManager.CarSelected = "Green";
        }
        else if (dropdown.value == 2)
        {
            gameManager.CarSelected = "Purple";
        }
    }
    //Save check
    public void CheckSave()
    {
        save = saving.LoadData();
        if(save != null)
        {
            saveCheck.SetActive(true);
            textbox.text = $"Name: {save.profileName}.\nCar Color: {save.carColor}.\nScore: {save.highScore}";
        }
    }
    public void CloseSave()
    {
        saveCheck.SetActive(false);
    }

    //Gameplay buttons
    public void YesSave()
    {
        recorder.SaveData();
        SceneManager.LoadScene("MainMenu");
    }
    public void NoSave()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
