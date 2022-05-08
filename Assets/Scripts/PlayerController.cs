using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private AudioClip pointSound;
    [SerializeField] private AudioClip deathSound;
    private GameManager gameManager;

    private Rigidbody2D playerRb;
    private PolygonCollider2D playerCollider;
    private AudioSource playerAudio;
    private float topBound = 3;
    public Vector2 flyDirection = new Vector2(0, 5);

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        playerRb = GetComponent<Rigidbody2D>();
        playerCollider = GetComponent<PolygonCollider2D>();
        playerAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Space) && gameManager.isPlaying == true)
        {
            Fly();
        }
    }

    void Fly() 
    {
        if (transform.position.y < topBound)
        {
            playerRb.velocity = flyDirection;
        }
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.CompareTag("WaterPile"))
        {
            playerAudio.PlayOneShot(deathSound);
            playerRb.velocity = new Vector2(0 , -5);
            playerCollider.isTrigger = true;
            gameManager.GameOver();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Plane"))
        {
            gameManager.GameOver();
            Destroy(gameObject);
        }

        else if (collision.gameObject.CompareTag("Score Point"))
        {
            gameManager.AddScore();
            playerAudio.PlayOneShot(pointSound);
        }
    }


}
