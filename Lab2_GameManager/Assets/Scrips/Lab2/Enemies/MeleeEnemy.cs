using System.Collections;
using UnityEngine;

public class MeleeEnemy : Enemy
{
    public float radius;
    public GameObject indi;
    public override void Attack()
    {
        Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, radius);
        StartCoroutine(AttackIndi());
        foreach (Collider2D hit in hits)
        {
            if (hit.gameObject.CompareTag("Player"))
            {
                Debug.Log("HurtPlayer");
                hit.gameObject.GetComponent<TopDownPlayerMovement>().TakeDamage(1);
            }
        }
    }

    IEnumerator AttackIndi()
    {
        indi.SetActive(true);
        yield return new WaitForSeconds(.5f);
        indi.SetActive(false);
    }
    
}
