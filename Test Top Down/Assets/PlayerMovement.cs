using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementTest : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Rigidbody2D rb;

    Vector2 movement;

    // Update is called once per frame
    void Update()
    {
      movement.x = Input.GetAxisRaw("Horizontal");
      movement.y = Input.GetAxisRaw("Vertical");

    }

    // Update is called on a fixed time (50 times a seconds)
    void FixedUpdate()
    {
       rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }

}
