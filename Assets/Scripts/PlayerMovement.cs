using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float speed = 5.0f;
    private Rigidbody2D rb;

    public bool speedBoost; //bool variable for power up cooldown
    public bool slowDown; //bool variable for oil spill debuff

    public GameObject p1bullet, bulletSpawn;
    public float fireRate = 1f;

    private float timer = 0;

    //keep score by tracking player 2 hits on this game object (player 1)

    private int player2Score = 0;
    public TextMeshProUGUI player2ScoreText;

    //define highest possible score to check for end of game
    public int highestScore;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float hrz = Input.GetAxis("P1Horizontal");
        float ver = Input.GetAxis("P1Vertical");

        Vector2 newVelocity = new Vector2(hrz, ver);
        rb.velocity = newVelocity * speed;

        //Tank moves in the direction of the movement key that is pressed

        Vector2 moveDirection = gameObject.GetComponent<Rigidbody2D>().velocity;
        if (moveDirection != Vector2.zero)
        {
            float angle = Mathf.Atan2(moveDirection.x, -moveDirection.y) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }

        //Add bullet fire code
        //Check if the Player 1 Fire button is pressed

        if (Input.GetAxis("P1Fire") > 0 && timer > fireRate)
        {
            AudioSource audioSource = gameObject.AddComponent<AudioSource>() as AudioSource;
            AudioClip bulletFireSound = Resources.Load<AudioClip>("Sounds/shot_fired");

            //If yes, spawn the bullet

            GameObject gObj;
            gObj = GameObject.Instantiate(p1bullet, bulletSpawn.transform.position, bulletSpawn.transform.rotation);
            audioSource.PlayOneShot(bulletFireSound);

            //Reset timer
            timer = 0;
        }

        timer += Time.deltaTime;
    }

    public void Player2Goal()
    {
        player2Score++;
        player2ScoreText.text = player2Score.ToString();
        ScoreCheck();
    }

    private void ScoreCheck()
    {
        if (player2Score == highestScore)
        {
            SceneManager.LoadScene(2);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "p2bullet") //if bullet hits
        {
            //Debug.Log("Player 1 Hit");
            //Debug.Log("Player 2 scores point");
            Player2Goal(); //add 1 to player 2 score
        }
    }
    
    void OnTriggerEnter2D(Collider2D other)
    {
        AudioSource audioSource = gameObject.AddComponent<AudioSource>() as AudioSource;
        AudioClip powerUpSound = Resources.Load<AudioClip>("Sounds/Powerup14");
        AudioClip crateBreakingSound = Resources.Load<AudioClip>("Sounds/crate");
        AudioClip oilSpillSound = Resources.Load<AudioClip>("Sounds/oil");

        if (other.CompareTag("PowerUp"))
        {
            audioSource.PlayOneShot(powerUpSound);
            speed = 3.5f;
            speedBoost = true;
            StartCoroutine(PowerUpCooldown());
            Destroy(other.gameObject);
        }
        if (other.CompareTag("Crate"))
        {
            audioSource.PlayOneShot(crateBreakingSound);
            speed = 3.5f;
            speedBoost = true;
            StartCoroutine(PowerUpCooldown());
            Destroy(other.gameObject);
        }
        if (other.CompareTag("OilSpill"))
        {
            audioSource.PlayOneShot(oilSpillSound);
            speed = 0.7f;
            slowDown = true;
            StartCoroutine(OilSpillCooldown());
        }
    }

    IEnumerator PowerUpCooldown()
    {
        yield return new WaitForSeconds(10.0f);
        speedBoost = false;
        speed = 2.0f;
    }
    IEnumerator OilSpillCooldown()
    {
        yield return new WaitForSeconds(1.5f);
        slowDown = false;
        speed = 2.0f;
    }
}
