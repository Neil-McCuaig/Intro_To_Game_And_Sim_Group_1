using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crates : MonoBehaviour
{
    public Sprite powerUpSprite;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "p1bullet" || other.gameObject.tag == "p2bullet")
        {
            GetComponent<AudioSource>().Play();
            GetComponent<SpriteRenderer>().sprite = powerUpSprite; //when crate is broken, change sprite to power up sprite
            transform.gameObject.tag = "PowerUp";
        }
    }
}
