using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 1f;

    public float maxSpeed = 2.2f;

    public SwordAttack swordAttack;

    Vector2 moveInput = Vector2.zero;
    SpriteRenderer spriteRenderer;
    Rigidbody2D rb;
    Animator animator;

    List<RaycastHit2D> castCollisions = new List<RaycastHit2D>();

    bool canMove = true;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void FixedUpdate()
    {
        if (canMove && moveInput != Vector2.zero)
        {

            rb.MovePosition(rb.position + moveInput * moveSpeed * Time.deltaTime);
            //rb.AddForce(moveInput * moveSpeed * Time.deltaTime);

            //Set direction of sprite to movement direction
            if (moveInput.x < 0)
            {
                spriteRenderer.flipX = true;
            }
            else if (moveInput.x > 0)
            {
                spriteRenderer.flipX = false;
            }

            animator.SetFloat("Horizontal", moveInput.x);
            animator.SetFloat("Vertical", moveInput.y);
            animator.SetBool("isMoving", true);
         }
        else
        {
            rb.velocity = Vector2.zero;
            animator.SetBool("isMoving", false);
        }  
    }

    public void SwordAttackFront()
    {
        LockMovement();
        swordAttack.AttackFront();
    }

    public void SwordAttackBack()
    {
        LockMovement();
        swordAttack.AttackBack();
    }

    public void SwordAttackSide()
    {
        LockMovement();
        if(spriteRenderer.flipX == true)
        {
            swordAttack.AttackLeft();
        }
        else
        {
            swordAttack.AttackRight();
        }

    }

    public void EndSwordAttack()
    {
        UnlockMovement();
        swordAttack.StopAttack();
    }

    void OnMove(InputValue movementValue)
    {
        moveInput = movementValue.Get<Vector2>();
    }

    void OnFire()
    {
        animator.SetTrigger("swordAttack");
    }

    public void LockMovement() { canMove = false; }
    public void UnlockMovement() { canMove = true; }
}
