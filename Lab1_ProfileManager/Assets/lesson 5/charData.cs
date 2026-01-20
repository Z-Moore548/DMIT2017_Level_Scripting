using UnityEngine;

public class charData 
{
    public string charaName;
    public Sprite portrait;
    public characterStats stats;
    public charData(CharacterScriptableObjetc config_)
    {
        charaName = config_.charaName;
        portrait = config_.portrait;

        stats.maxHP = config_.stats.maxHP;
        
    }
}
