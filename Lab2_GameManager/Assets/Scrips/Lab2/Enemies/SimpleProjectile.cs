using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class SimpleProjectile : MonoBehaviour
{
    Rigidbody2D rb;
    public float speed, duration;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void InstantiateProjectile(Vector2 dir_)
    {
        rb.linearVelocity = dir_ * speed;
        StartCoroutine(ProjectileTimer());
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<TopDownPlayerMovement>().TakeDamage(1);
        }
    }

    public IEnumerator ProjectileTimer()
    {
        yield return new WaitForSeconds(duration);
        yield return new WaitForEndOfFrame();
        Destroy(this.gameObject);
    }
}
