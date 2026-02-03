using System.Collections;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    public string enemyName;
    public int HP, ATK, DEF, speed;

    public float attackDelay;
    public CircleOverlap sightLine, attackRange;
    public Vector2 playerPosition;
    private Coroutine attackCoroutine;

    public abstract void Patrol();
    public abstract void Attack();
    public abstract void TakeDamage(float dmg_);
    public abstract void Die();
    public abstract void Pursue();
    void Awake()
    {
        sightLine.OnOverlap += SetPlayerPosition;
        attackRange.OnOverlap += SetPlayerPosition;
    }

    public void SetPlayerPosition(Vector2 pos_)
    {
        playerPosition = pos_;
    }
    void Update()
    {
        if (sightLine.CircleOverlapCheck())
        {
            Pursue();
        }
        if (attackRange.CircleOverlapCheck())
        {
            
            StartAttackCouroutine();
        }
        else
        {
           StopAllCoroutines();
        }
    }
    public void StartAttackCouroutine()
    {
        if(attackCoroutine == null) attackCoroutine = StartCoroutine(AttackCouroutine());
    }
    public IEnumerator AttackCouroutine()
    {
        while (true)
        {
            Attack();
            yield return new WaitForSeconds(attackDelay);
        }
        yield return null;
    }


}
