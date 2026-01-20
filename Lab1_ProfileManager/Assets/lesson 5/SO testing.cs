using System.Xml;
using UnityEngine;

public class SOtesting : MonoBehaviour
{
    public CharacterScriptableObjetc goku;
    public charData characterData; 
    void Start()
    {
        Concentrate();
    }
    public void Concentrate()
    {
        goku.stats.atk *= 2;
    }
}
