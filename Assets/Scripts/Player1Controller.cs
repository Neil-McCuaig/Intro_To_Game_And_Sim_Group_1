using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1Controller : MonoBehaviour
{

    public float speed;
    public float minX, minY, maxX, maxY;

    private Rigidbody2D rBody;

    // Start is called before the first frame update
    void Start()
    {
        rBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float horiz, vert;

        horiz = Input.GetAxis("Player1-Horiz");
        vert = Input.GetAxis("Player1-Vert");

        //Debug.Log("H: " + horiz + " V: " + vert);

        Vector2 newVelocity = new Vector2(horiz, vert);
        rBody.velocity = newVelocity * speed;

        //Restrict the player from leaving the play area
        float newX, newY;

        newX = Mathf.Clamp(rBody.position.x, minX, maxX);
        newY = Mathf.Clamp(rBody.position.y, minY, maxY);

        rBody.position = new Vector2(newX, newY);

    }

}
