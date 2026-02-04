using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(AIMovement))]
public abstract class Enemy : MonoBehaviour
{
    [Header("Combat Params")]
    public int HP;
    public int ATK;
    public int DEF;
    public float attackDelay;

    [Header("Behavior Ranges")]
    public CircleOverlap sightline;
    public CircleOverlap attackRange;

    public Vector2 playerPosition;
    private Coroutine attackCoroutine;

    public Vector2 patrolRange;
    private Vector2 startingPosition;
    private Vector2 nextPosition;
    private AIMovement aiMovement;

    private bool patroling;

    private void Awake()
    {
        sightline.OnOverlap += SetPlayerPosition;
        attackRange.OnOverlap += SetPlayerPosition;
        aiMovement = GetComponent<AIMovement>();
        aiMovement.OnArrive += Patrol;
        startingPosition = transform.position;
    }

    public void SetPlayerPosition(Vector2 pos_)
    {
        playerPosition = pos_;
    }
    [ContextMenu("Patrol")]
    public void Patrol()
    {
        nextPosition = new Vector2(Random.Range(startingPosition.x - patrolRange.x, startingPosition.x + patrolRange.x),
            Random.Range(startingPosition.y - patrolRange.y, startingPosition.y + patrolRange.y));
        aiMovement.InitializeMovement(nextPosition);
    }

  

 
    public abstract void Attack();
    public void TakeDamage(int dmg_)
    {
        HP -= dmg_;
    }
    public abstract void Die();
    public void Pursue()
    {
        aiMovement.InitializeMovement(playerPosition);
    }



    private void Update()
    {
        if (attackRange.CircleOverlapCheck())
        {
            aiMovement.StopMovement();
            StartAttackCoroutine();
            return;
        }

        if (sightline.CircleOverlapCheck())
        {
            Pursue();
            return;
        }
        if (!patroling)
        {
            Patrol();
            patroling = true;
        }
    }
    public void StartAttackCoroutine()
    {
        if(attackCoroutine == null) attackCoroutine = StartCoroutine(AttackCoroutine());
    }
    public IEnumerator AttackCoroutine()
    {
        while (true)
        {
            Attack();
            yield return new WaitForSeconds(attackDelay);
        }
       // yield return null;
    }

}
