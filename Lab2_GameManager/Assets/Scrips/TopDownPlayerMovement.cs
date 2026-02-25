using System;
using System.Collections;
using Unity.VectorGraphics;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class TopDownPlayerMovement : MonoBehaviour
{
    public InputAction moveInput, attackAction, interactAction;
    private Vector2 movementDirection = Vector2.zero;
    public float moveSpeed;
    public int currentHP, maxHP, tresureCollected;
    public event Action<Vector2> OnMove;
    Rigidbody2D rb;
    public bool interact;
    public GameObject indi, savingText;
    private void Awake()
    {
        moveInput.Enable();
        attackAction.Enable();
        interactAction.Enable();
        rb = GetComponent<Rigidbody2D>();
        savingText.SetActive(false);

        moveInput.performed += GetMoveVector;
        moveInput.canceled += GetMoveVector;
        attackAction.performed += AttackInput;
        interactAction.performed += InteractInput;

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
        StartCoroutine(AttackIndi());
        foreach (Collider2D hit in hits)
        {
            if (hit.gameObject.CompareTag("Enemy"))
            {
                hit.GetComponent<Enemy>().TakeDamage(2);
            }
        }

    }
    public void InteractInput(InputAction.CallbackContext c)
    {
        interact = true;
    }


    public void TakeDamage(int dmg_)
    {
        currentHP -= dmg_;
        if(currentHP <= 0)
        {
            SceneManager.LoadScene("MainMenu");
        }
    }
    public void RestoreHP()
    {
        currentHP = maxHP;
        savingText.SetActive(true);
        StartCoroutine(SavingThing());
    }

    IEnumerator AttackIndi()
    {
        indi.SetActive(true);
        yield return new WaitForSeconds(.5f);
        indi.SetActive(false);
    }
    IEnumerator SavingThing()
    {
        yield  return new WaitForSeconds(2);
        savingText.SetActive(false);
    }
}
