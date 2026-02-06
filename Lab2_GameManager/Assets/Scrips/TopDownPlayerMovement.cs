using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class TopDownPlayerMovement : MonoBehaviour
{
    public InputAction moveInput, attackAction;
    private Vector2 movementDirection = Vector2.zero;
    public float moveSpeed;
    public event Action<Vector2> OnMove;
    Rigidbody2D rb;
    private void Awake()
    {
        moveInput.Enable();
        attackAction.Enable();
        rb = GetComponent<Rigidbody2D>();
        moveInput.performed += GetMoveVector;
        moveInput.canceled += GetMoveVector;
        attackAction.performed += AttackInput;

    }

    public void GetMoveVector(InputAction.CallbackContext c)
    {
        movementDirection = c.ReadValue<Vector2>();
        OnMove?.Invoke(movementDirection);
        
    }

    private void FixedUpdate()
    {
        //transform.position += new Vector3(movementDirection.x, movementDirection.y, 0) * moveSpeed * Time.deltaTime;
        rb.AddForce(movementDirection * moveSpeed * Time.fixedDeltaTime);
    }

    public void AttackInput(InputAction.CallbackContext c)
    {
        Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, 2);
        foreach (Collider2D hit in hits)
        {
            if (hit.gameObject.CompareTag("Enemy"))
            {
                hit.GetComponent<Enemy>().TakeDamage(2);
            }
        }

    }
}
