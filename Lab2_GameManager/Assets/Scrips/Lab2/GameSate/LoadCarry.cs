using UnityEngine;

public class LoadCarry : MonoBehaviour
{
    public static LoadCarry Instance;
    public bool load;

    void Awake()
    {
        if(Instance == null)
        {
            
        }
        else
        {
            Instance = this;
        }
        DontDestroyOnLoad(this.gameObject);
    }
}
