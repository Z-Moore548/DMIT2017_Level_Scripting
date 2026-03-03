using NUnit.Framework;
using System;
using System.Collections.Generic;
using UnityEngine;

public class GameStateManager : MonoBehaviour
{
    public static GameStateManager Instance;
    //public List<MapState> mapStates = new List<MapState>();
    public GameState gameState;
    public Transform mapParent;
    private EnemySpawner spawner;
    private Tresure tresure;
    private int currentMapID;
    private MapState currentMapState;
    public Saving saving;
    public LoadCarry carry;

    private void Awake()
    {
        Instance = this;
        saving = Saving.Instance;
        carry = GameObject.FindGameObjectWithTag("Carry").GetComponent<LoadCarry>();
        
    }
    private void Start()
    {
        if(carry.load == true)
        {
            Debug.Log("WHAY");
            gameState = saving.LoadData();
        }
        foreach(MapState mapState in gameState.mapStates)
        {
            mapState.InitializeDictionary();
        }

        InitializeMap(0);
    }
    public void InitializeMap(int mapID_)
    {
       
        foreach (MapState mapState in gameState.mapStates)
        {
            if(mapState.mapID == mapID_)
            {
                currentMapState = mapState;
                BeginEnemySpawn(currentMapState);
                BeginTresureSpawn(currentMapState);
                break;
            }
        }
    }

    public void BeginEnemySpawn(MapState map)
    {
        spawner = mapParent.GetComponentInChildren<EnemySpawner>();
        foreach(EnemyState enemy in map.enemyStates)
        {

            if(enemy.currentHP > 0) spawner.Spawn(enemy.enemyID, enemy.currentHP);
        }
    }
    public void ResetEnemies()
    {
        foreach(MapState m in gameState.mapStates)
        {
            foreach(EnemyState s in m.enemyStates)
            {
                s.currentHP = s.maxHP;
            }
        }
    }
    public void BeginTresureSpawn(MapState map)
    {
        if(map.mapID != 3 || map.mapID != 5)
        {
            tresure = mapParent.GetComponentInChildren<Tresure>();
            tresure.ShowTresure(map.tresureCollected);
        }
    }

    [ContextMenu("Try Save")]
    public void SaveGameState()
    {
        if (spawner != null)
        {
            List<Enemy> enemies = spawner.activeEnemies;
            foreach (Enemy enemy in enemies)
            {
                currentMapState.enemyDictionary[enemy.enemyID].currentHP = enemy.HP;
                Debug.Log(currentMapState.enemyDictionary[enemy.enemyID].currentHP);
                currentMapState.tresureCollected = tresure.gotIt;
            }
        }
        
    }
}

[Serializable] 
public class MapState
{
    public int mapID;
    public bool tresureCollected;
    public List<EnemyState> enemyStates;
    [NonSerialized] public Dictionary<int, EnemyState> enemyDictionary;

    public void InitializeDictionary()
    {
        enemyDictionary = new Dictionary<int, EnemyState>();
        foreach(EnemyState enemy in enemyStates)
        {
            enemyDictionary.Add(enemy.enemyID, enemy);
        }
    }
}

[Serializable]
public class EnemyState
{
    public int enemyID;
    public int currentHP;
    public int maxHP;
}

[Serializable]
public class GameState
{
    public List<MapState> mapStates;
}
