using Unity.VectorGraphics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLine : MonoBehaviour
{
    [SerializeField] GhostDataRecorder recorder;
    void Start()
    {
        recorder = GameObject.FindGameObjectWithTag("Player").gameObject.GetComponentInParent<GhostDataRecorder>();
    }
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            recorder.SaveData();
            //SceneManager.LoadScene("MainMenu");
        }
    }
}
