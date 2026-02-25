using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public TMP_Text health, tresure;
    public TopDownPlayerMovement player;
    public GameObject pause;
    void Update()
    {
        health.text = $"Current Health: {player.currentHP}";
        tresure.text = $"Tresure Collected: {player.tresureCollected}";
        if (Keyboard.current.escapeKey.wasPressedThisFrame)
        {
            PauseGame();
        }
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
        pause.SetActive(true);
    }

    public void onResume()
    {
        Time.timeScale = 1;
        pause.SetActive(false);
    }
    public void onMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("MainMenu");
    }
}
