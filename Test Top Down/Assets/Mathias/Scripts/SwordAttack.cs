using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordAttack : MonoBehaviour
{
    BoxCollider2D swordCollider;
    public float damage = 3;

    private void Start()
    {
        swordCollider = GetComponent<BoxCollider2D>();
    }

    public void AttackRight()
    {
        swordCollider.offset = new Vector2(0.1f, -0.12f);
        swordCollider.size = new Vector2(0.15f,0.15f); 
        swordCollider.enabled = true;
    }
    public void AttackLeft()
    {
        swordCollider.offset = new Vector2(-0.11f, -0.12f);
        swordCollider.size = new Vector2(0.15f, 0.15f);
        swordCollider.enabled = true;
    }
    public void AttackFront()
    {
        swordCollider.offset = new Vector2(-0.01f, -0.2f);
        swordCollider.size = new Vector2(0.2f, 0.07f);
        swordCollider.enabled = true;
    }
    public void AttackBack()
    {
        swordCollider.offset = new Vector2(0, -0.02f);
        swordCollider.size = new Vector2(0.2f, 0.07f);
        swordCollider.enabled = true;
    }

    public void StopAttack()
    {
        swordCollider.enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        print("Hit");
        if(other.CompareTag("Enemy"))
        {
            Enemy enemy = other.GetComponent<Enemy>();

            if (enemy != null)
            {
                print(enemy.Health);
                enemy.Health -= damage;
            }
        }
    }
}
