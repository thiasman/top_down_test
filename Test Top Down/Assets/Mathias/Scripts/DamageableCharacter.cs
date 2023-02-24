using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageableCharacter : MonoBehaviour, IDamageable
{
    public float health = 3f;
    Animator animator;
    public Rigidbody2D rb;

    //private bool isAttacking = false;

    public float Health
    {
        set
        {
            health = value;
            if (health <= 0)
            {
                Defeated();
            }
        }
        get
        {
            return health;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        animator.SetBool("isAlive", true);
    }


    public void Defeated()
    {
        animator.SetBool("isAlive", false);
    }

    public void DestroyCharacter()
    {
        Destroy(gameObject);
    }


    public void OnHit(float damage, Vector2 knockback)
    {
        Health -= damage;
        if (!this.CompareTag("Player"))
        {
            animator.SetTrigger("isHit");
            rb.AddForce(knockback);
        }
        else
        {
            rb.AddForce(knockback);
        }

    }

    public void OnHit(float damage)
    {
        Health -= damage;
        animator.SetTrigger("isHit");
    }

}
