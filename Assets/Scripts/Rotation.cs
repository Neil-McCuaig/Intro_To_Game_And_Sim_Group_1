using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    private float move;
    public float moveSpeed;

    private float rotation;
    public float rotateSpeed;

    public GameObject p1bullet, bulletSpawn;
    public float fireRate = 0.75f;

    private Rigidbody2D rBody;
    private float timer = 0;

    // Start is called before the first frame update
    void Start()
    {
        moveSpeed = 5f;
        rotateSpeed = 50f;
    }

    // Update is called once per frame
    void Update()
    {
        move = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
        rotation = Input.GetAxis("Horizontal") * -rotateSpeed * Time.deltaTime;

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

    private void LateUpdate()
    {
        transform.Translate(0f, move, 0f);
        transform.Rotate(0f, 0f, rotation);
    }
}