using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class Player2Movement : MonoBehaviour
{
    [SerializeField] float speed = 5.0f;
    private Rigidbody2D rb;

    public bool speedBoost; //bool variable for power up cooldown

    public GameObject p2bullet, p2bulletSpawn;
    public float fireRate = 0.75f;

    private float timer = 0;

    //keep score by tracking player 1 hits on this game object (player 2)
    private int player1Score = 0;
    public TextMeshProUGUI player1ScoreText;

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

    public void Player1Goal()
    {
        player1Score++;
        player1ScoreText.text = player1Score.ToString();
        ScoreCheck();
    }

    private void ScoreCheck()
    {
        if (player1Score == highestScore)
        {
            SceneManager.LoadScene(2);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "p1bullet") //if bullet hits
        {
            Player1Goal(); //add 1 to player 1 score
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        AudioSource audioSource = gameObject.AddComponent<AudioSource>() as AudioSource;
        AudioClip powerUpSound = Resources.Load<AudioClip>("Sounds/Powerup14");
        AudioClip crateBreakingSound = Resources.Load<AudioClip>("Sounds/crate");

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
    }

    IEnumerator PowerUpCooldown()
    {
        yield return new WaitForSeconds(10.0f);
        speedBoost = false;
        speed = 2.0f;
    }
}
