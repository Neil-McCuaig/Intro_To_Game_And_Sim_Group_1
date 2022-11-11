using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    public int speed = 10;
    public Vector2 direction;
    public float lifetime = 5f;
    private Rigidbody2D rb;

    void Start()
    {
        // Get RigidBody
        rb = gameObject.GetComponent<Rigidbody2D>();

        // Add Force
        rb.AddForce(direction.normalized * speed);

        // Add Velocity
        rb.velocity = new Vector2(speed, 0.0f);
    }

    // Update is called once per frame
    void Update()
    {
        // Decrease the timer
        lifetime -= Time.deltaTime;

        if (lifetime <= 0f)
        {
            // When timer runs out, destroy the bullet
            Destroy(gameObject);
        }
    }
}