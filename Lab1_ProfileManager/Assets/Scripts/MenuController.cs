using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class MenuController : MonoBehaviour
{
    GameManager gameManager;
    public TMP_InputField text;
    public GameObject confim;
    public GhostDataRecorder recorder;
    void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager").gameObject.GetComponent<GameManager>();
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
