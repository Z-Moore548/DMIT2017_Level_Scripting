using System.IO;
using System.Text.RegularExpressions;
using UnityEngine;

public class GhostDataRecorder : MonoBehaviour
{
    public GhostData ghostData = new GhostData();
    private bool recording;
    public  JSonSaving saving;
    public GameManager gameManager;

    private void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager").gameObject.GetComponent<GameManager>();
        saving = GameObject.FindGameObjectWithTag("Saving").gameObject.GetComponent<JSonSaving>();
        StartRecording();
    }
    public void StartRecording()
    {
        recording = true;
    }

    public void Update()
    {
        if (!recording) return;

        ghostData.AddFrame(transform.position, transform.eulerAngles);
    }

    public void SaveData()
    {
        saving.SaveData(gameManager.ProfileSelected, ghostData.ghostDataFrames.Count, ghostData, gameManager.CarSelected);
    }
}
