using UnityEngine;

public class MeleeEnemy : Enemy
{
    public float radius;
    public override void Attack()
    {
        Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, radius);

        foreach (Collider2D hit in hits)
        {
            if (hit.gameObject.CompareTag("Player"))
            {
                Debug.Log("HurtPlayer");
            }
        }
    }
    
}
