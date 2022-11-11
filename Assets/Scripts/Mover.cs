using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    public float speed = 10.0f;
    private Vector2 startPosition;
    private Rigidbody2D rb;

    // Start is called before the first frame update

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        startPosition = transform.position;
        //rb.velocity = transform.right * speed;
        rb.velocity = new Vector2(speed, 0.0f);
    }

}
