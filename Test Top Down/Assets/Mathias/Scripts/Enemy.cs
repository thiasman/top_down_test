using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float damage = 1f;
    public float knockbackForce = 5000f;
    Animator animator;

    public float speed = 0.4f;
    public float attackRange = 0.1f;
    public GameObject player;

    public Rigidbody2D rb;

    private bool isAttacking = false;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        player = GameObject.FindGameObjectsWithTag("Player")[0];
    }

    void FixedUpdate()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, player.transform.position);

        if (distanceToPlayer > attackRange)
        {
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
            animator.SetBool("isMoving", true);
        }
        else
        {
            animator.SetBool("isMoving", false);
            if (!isAttacking)
            {
                //Debug.Log("Player hit");
            }
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {

        IDamageable damageableObject = col.collider.GetComponent<IDamageable>();

        if (damageableObject != null)
        {
            Vector2 direction =  (col.collider.transform.position - transform.position).normalized;
            Vector2 knockback = direction * knockbackForce;
            Debug.Log(knockback);
            damageableObject.OnHit(damage, knockback);
        }
    }
}
