using UnityEngine;

public class GhostDataManger : MonoBehaviour
{
    public JSonSaving saving;
    public GameObject ghost;
    SaveData save;
    int index;
    void Start()
    {
        save = saving.LoadData();
    }
    void Update()
    {
        if(save != null && index < save.ghostData.ghostDataFrames.Count)
        {
            ghost.transform.position = save.ghostData.ghostDataFrames[index].position;
            ghost.transform.rotation = Quaternion.Euler(save.ghostData.ghostDataFrames[index].rotation);
            index++;
        }
    }
}
