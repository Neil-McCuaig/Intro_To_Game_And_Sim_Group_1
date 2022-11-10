using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float minX, minY, maxX, maxY;

    public GameObject p1bullet, bulletSpawn;
    public float fireRate = 0.75f;

    private Rigidbody2D rBody;
    private float timer = 0;

    // Start is called before the first frame update
    void Start()
    {
        rBody = GetComponent<Rigidbody2D>();
    }

    //FixedUpdate ties the speed to a 50-times-per-second timer rather than the framerate
    void FixedUpdate()
    {
        float horiz = Input.GetAxis("Horizontal");
        float vert = Input.GetAxis("Vertical");

        Vector2 newVelocity = new Vector2(horiz, vert);
        rBody.velocity = newVelocity * speed;

        //Restrict the player from leaving the play area
        float newX, newY;

        newX = Mathf.Clamp(rBody.position.x, minX, maxX);
        newY = Mathf.Clamp(rBody.position.y, minY, maxY);

        rBody.position = new Vector2(newX, newY);

        //Add bullet fire code
        //Check if the Player 1 Fire button is pressed

        if (Input.GetAxis("Fire") > 0 && timer > fireRate)
        {
            //If yes, spawn the bullet

            GameObject gObj;
            gObj = GameObject.Instantiate(p1bullet, bulletSpawn.transform.position, bulletSpawn.transform.rotation);

            //Reset timer
            timer = 0;
        }

        timer += Time.deltaTime;
    }

}
