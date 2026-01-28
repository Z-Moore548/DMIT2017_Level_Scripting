using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MapNavagation : MonoBehaviour
{
    public static MapNavagation Instance;

    [SerializeField] private Transform player;
    [SerializeField] private MapLibrary library;
    [SerializeField] private Transform mapParent;
    private Dictionary<int, MapData> mapDictionary = new Dictionary<int, MapData>();
    [SerializeField] private GameObject currentMap;
    private void Awake()
    {
        if(Instance == null) Instance = this;
    }

    private void Start()
    {
        InitializeMapDictionary();
    }

    private void InitializeMapDictionary()
    {
        mapDictionary.Clear();
        foreach(GameMap m in library.mapLibrary)
        {
            mapDictionary.Add(m.mapID, new MapData(m));
        }
    }

    public void GoToMap(int mapID, int portalID)
    {
        // destroy the current map
        // instantiate the new map under the corresponding parent
        // move the player to the designated cell


        Destroy(currentMap);

        currentMap = Instantiate(mapDictionary[mapID].prefab, mapParent);
        Grid g = mapParent.GetComponent<Grid>();
        player.position = g.GetCellCenterWorld(mapDictionary[mapID].entryPoints[portalID].cell);
    }
}

public class MapData
{
    public GameObject prefab;
    public string mapName;
    public int mapID;

    public Dictionary<int, MapEntryPoint> entryPoints = new Dictionary<int, MapEntryPoint>();

    public MapData(GameMap config)
    {
        this.prefab = config.prefab;
        this.mapID = config.mapID;
        this.mapName = config.mapName;

        foreach (MapEntryPoint m in config.entryPoints)
        {
            entryPoints.Add(m.entryPointId, m);
        }
    }
}
