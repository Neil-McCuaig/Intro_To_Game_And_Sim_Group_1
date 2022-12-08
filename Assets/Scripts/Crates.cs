using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crates : MonoBehaviour
{
    public Sprite powerUpSprite;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("p1bullet") || other.CompareTag("p2bullet"))
        {
            GetComponent<SpriteRenderer>().sprite = powerUpSprite; //when crate is broken, change sprite to power up sprite
            transform.gameObject.tag = "PowerUp";
        }
    }
}
