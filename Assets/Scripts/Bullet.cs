using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;
    public GameObject explosion;

    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = -transform.up * speed;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        AudioSource audioSource = gameObject.AddComponent<AudioSource>() as AudioSource;
        AudioClip ricochetSound = Resources.Load<AudioClip>("Sounds/ricochet");

        if (collision.gameObject.name == "Player2_Blue") //if bullet hits player 2
        {
            //Debug.Log("Player 2 Hit");
            var explosionAnimation = Instantiate(explosion, transform.position, transform.rotation); //instantiate explosion animation
            Destroy(explosionAnimation, 0.5f);
            Destroy(gameObject);
        }
        if (collision.gameObject.tag == "Objects") //if bullet hits gameObjects with the Objects tag
        {
            //instantiate ricochet sound
            audioSource.PlayOneShot(ricochetSound);
            //destroy bullet prefab if it doesn't hit player after 2 seconds
            Destroy(this.gameObject, 2);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        AudioSource audioSource = gameObject.AddComponent<AudioSource>() as AudioSource;
        AudioClip crateBreakingSound = Resources.Load<AudioClip>("Sounds/crate");

        if (collision.gameObject.tag == "Crate")
        {
            audioSource.PlayOneShot(crateBreakingSound);
        }
    }
}
