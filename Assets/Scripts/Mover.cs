using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    public float speed = 10.0f;

    private Vector2 startPosition;
    private Rigidbody2D rb;

    // Start is called before the first frame update
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void Initialize()
    {
        startPosition = transform.position;
        rb.velocity = transform.up * speed;
    }

}
