using UnityEngine;

public class RangedEnemy : Enemy
{
    [Header("Projectile Info")]
    public GameObject projectilePrefab;
    public Transform projectileSpawnLocation;
    public override void Attack()
    {
        // instantiate a projectile
        // give the projectile a direction + velocity
        // projectile handles collisions 

        GameObject obj = Instantiate(projectilePrefab, projectileSpawnLocation.position, Quaternion.identity);
        SimpleProjectile projectile = obj.GetComponent<SimpleProjectile>();
        projectile.InstantiateProjectile(new Vector2(playerPosition.x - transform.position.x, playerPosition.y - transform.position.y));
    }

    public override void Die()
    {
        throw new System.NotImplementedException();
    }
}
