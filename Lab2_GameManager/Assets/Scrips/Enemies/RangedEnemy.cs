using Unity.Mathematics;
using UnityEngine;

public class RangedEnemy : Enemy
{
    public GameObject projectilePrefab;
    public Transform porjectileSpawnLocation;
    
    
    public override void Attack()
    {
        GameObject obj = Instantiate(projectilePrefab, porjectileSpawnLocation.position, Quaternion.identity);
        SimpleProjectile projectile = obj.GetComponent<SimpleProjectile>();
        projectile.InstantiateProjectile(new Vector2(playerPosition.x - transform.position.x, playerPosition.y - transform.position.y).normalized);
    }

    public override void Die()
    {
        throw new System.NotImplementedException();
    }

    public override void Patrol()
    {
        throw new System.NotImplementedException();
    }

    public override void Pursue()
    {
        transform.position = Vector2.MoveTowards(transform.position, playerPosition, (speed * Time.deltaTime));
    }

    public override void TakeDamage(float dmg_)
    {
        throw new System.NotImplementedException();
    }
}
