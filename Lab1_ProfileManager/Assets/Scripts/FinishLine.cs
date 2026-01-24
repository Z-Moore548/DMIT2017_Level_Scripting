using Unity.VectorGraphics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLine : MonoBehaviour
{
    [SerializeField] GhostDataRecorder recorder;
    public GameObject canvas;
    void Start()
    {
        //recorder = GameObject.FindGameObjectWithTag("Player").gameObject.GetComponentInParent<GhostDataRecorder>();
    }
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            recorder = GameObject.FindGameObjectWithTag("Player").gameObject.GetComponentInParent<GhostDataRecorder>();
            canvas.SetActive(true);
            // recorder.SaveData();
            // SceneManager.LoadScene("MainMenu");
        }
    }
}
