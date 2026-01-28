using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(fileName = "GameMap", menuName = "Navigation/GameMap")]
public class GameMap : ScriptableObject
{
    public GameObject prefab;
    public string mapName;
    public int mapID;
    public List<MapEntryPoint> entryPoints;
}
[Serializable]
public class MapEntryPoint
{
    public int entryPointId;
    public Vector3Int cell;
}
