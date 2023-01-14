using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 150f;

    public float maxSpeed = 8f;

    public float idleFriction = 0.9f;

    public ContactFilter2D movementFilter;

    public SwordAttack swordAttack;

    Vector2 moveInput;
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
        if (canMove)
        {
            //if movement input is not 0, try to move
            if (moveInput != Vector2.zero)
            {
                /*                bool success = TryMove(moveInput);

                                if (!success)
                                {
                                    //Try moving in both direction when moving diagonally to slide instead of being blocked
                                    success = TryMove(new Vector2(moveInput.x, 0));

                                }
                                if (!success)
                                {
                                    success = TryMove(new Vector2(0, moveInput.y));
                                }*/
                rb.velocity = Vector2.ClampMagnitude(rb.velocity + (moveInput * moveSpeed * Time.deltaTime), maxSpeed);
                animator.SetFloat("Horizontal", moveInput.x);
                animator.SetFloat("Vertical", moveInput.y);
                animator.SetBool("isMoving", true);
            }
            else
            {
                rb.velocity = Vector2.Lerp(rb.velocity, Vector2.zero, idleFriction) ;
                animator.SetBool("isMoving", false);
            }

            //Set direction of sprite to movement direction
            if (moveInput.x < 0)
            {
                spriteRenderer.flipX = true;
            }
            else if (moveInput.x > 0)
            {
                spriteRenderer.flipX = false;
            }
        }

    }

/*    private bool TryMove(Vector2 direction)
    {
        if (direction != Vector2.zero)
        {
            //check for potential collision
            int count = rb.Cast(
                direction, // x and y values between -1 and 1 that represent the direction from the body to look for collisions
                movementFilter, // The settings that determine where a collision can occur
                castCollisions, // List of collisions to store the found ones
                moveSpeed * Time.fixedDeltaTime + collisionOffset);

            if (count == 0)
            {
                rb.MovePosition(rb.position + direction * moveSpeed * Time.fixedDeltaTime);
                animator.SetFloat("Horizontal", direction.x);
                animator.SetFloat("Vertical", direction.y);
                return true;
            }
            else
            {
                return false;
            }
        }
        else {
            // Can't move if there's no direction to move in
            return false;
        } 
    }*/

    public void SwordAttackFront()
    {
        print("Attack Front");
        LockMovement();
        swordAttack.AttackFront();
    }

    public void SwordAttackBack()
    {
        print("Attack Back");
        LockMovement();
        swordAttack.AttackBack();
    }

    public void SwordAttackSide()
    {
        LockMovement();
        if(spriteRenderer.flipX == true)
        {
            print("Attack Left");
            swordAttack.AttackLeft();
        }
        else
        {
            print("Attack Right");
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
