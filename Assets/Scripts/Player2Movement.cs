using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2Movement : MonoBehaviour
{
    [SerializeField] float speed = 5.0f;
    private Rigidbody2D rb;

    public GameObject p2bullet, p2bulletSpawn;
    public float fireRate = 0.75f;
    private float timer = 0;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float hrz = Input.GetAxis("P2Horizontal");
        float ver = Input.GetAxis("P2Vertical");

        Vector2 newVelocity = new Vector2(hrz, ver);
        rb.velocity = newVelocity * speed;

        Vector2 moveDirection = gameObject.GetComponent<Rigidbody2D>().velocity;
        if (moveDirection != Vector2.zero)
        {
            float angle = Mathf.Atan2(moveDirection.x, -moveDirection.y) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }

        //Add bullet fire code
        //Check if the Player 1 Fire button is pressed

        if (Input.GetAxis("P2Fire") > 0 && timer > fireRate)
        {
            //If yes, spawn the bullet

            GameObject gObj;
            gObj = GameObject.Instantiate(p2bullet, p2bulletSpawn.transform.position, p2bulletSpawn.transform.rotation);

            //Reset timer
            timer = 0;
        }

        timer += Time.deltaTime;
    }
}