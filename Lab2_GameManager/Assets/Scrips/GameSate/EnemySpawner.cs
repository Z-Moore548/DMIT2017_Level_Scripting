using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public Transform[] spawnPoints;
    public List<Enemy> activeEnemies = new List<Enemy>();

    public void Spawn(EnemyState enemyData, int hp)
    {
        Transform spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
        GameObject tmp = Instantiate(enemyData.enemySO.prefab, spawnPoint.position, Quaternion.identity);

        Enemy e = tmp.GetComponent<Enemy>();
        e.HP = hp;
        activeEnemies.Add(e);
        e.enemyID = enemyData.enemyID;
        e.ATK = enemyData.enemySO.ATK;
        e.DEF = enemyData.enemySO.DEF;
    }
}
