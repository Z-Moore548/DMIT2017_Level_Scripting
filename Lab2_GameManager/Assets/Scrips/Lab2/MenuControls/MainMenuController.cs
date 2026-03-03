using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour
{
    GameState gameState;
    public GameObject loadbutton;
    void Start()
    {
        gameState = Saving.Instance.LoadData();
        if(gameState == null)
        {
            loadbutton.GetComponent<Button>().interactable = false;
        }
    }
    public void OnNewGame()
    {
        Saving.Instance.DeleteFile();
        GameObject.FindGameObjectWithTag("Carry").GetComponent<LoadCarry>().load = false;
        SceneManager.LoadScene("SampleScene");
    }
    public void OnLoadGame()
    {
        GameObject.FindGameObjectWithTag("Carry").GetComponent<LoadCarry>().load = true;
        SceneManager.LoadScene("SampleScene");
    }
    public void OnQuit()
    {
        Application.Quit();
    }
}
