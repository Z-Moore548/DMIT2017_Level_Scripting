using System;
using UnityEngine;

[CreateAssetMenu(fileName = "CharacterScriptableObjetc", menuName = "Scriptable Objects/CharacterScriptableObjetc")]
public class CharacterScriptableObjetc : ScriptableObject
{
    public string charaName;
    public Sprite portrait;
    public characterStats stats;
    
    
}
[Serializable]
public class characterStats
{
    public int maxHP;
    public int currentHp;
    public int maxSP;
    public int currentSP;
    public int atk;

    public characterStats(characterStats ref_)
    {
        maxHP = ref_.maxHP;
        currentHp = ref_.currentHp;
        maxSP = ref_.maxSP;
        currentSP = ref_.currentHp;
        atk = ref_.atk;
    }
}
