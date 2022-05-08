using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePile : MonoBehaviour
{
    private Rigidbody2D pileRb;
    private Vector2 moveDirection = new Vector2(-2, 0);
    private float xBound = -15;

    private GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();

        pileRb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        DestroyPile();

        if (gameManager.isPlaying)
        {
            pileRb.velocity = moveDirection;
        }

        else
        {
            pileRb.velocity = new Vector2(0, 0);
        }
        
    }

    void DestroyPile()
    {
        if (transform.position.x < xBound)
        {
            Destroy(gameObject);
        }
    }
}
