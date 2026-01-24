using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    [SerializeField] string profileSelected;
    [SerializeField] string carSelected;

    public string ProfileSelected { get => profileSelected; set => profileSelected = value; }
    public string CarSelected { get => carSelected; set => carSelected = value; }

    void Awake()
    {
        if (instance == null) // changed it to this dont know if it will meld with my code or if ill have to change other things
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);
    }
}
