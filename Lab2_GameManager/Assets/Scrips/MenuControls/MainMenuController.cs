using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    GameState gameState;
    public void OnNewGame()
    {
        SceneManager.LoadScene("SampleScene");
    }
    public void OnLoadGame()
    {
        gameState = Saving.Instance.LoadData();// Need to carry this data bewteen scenenes
        //SceneManager.LoadScene("SampleScene");
    }
    public void OnQuit()
    {
        Application.Quit();
    }
}
