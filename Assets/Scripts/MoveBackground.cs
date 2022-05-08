using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBackground : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
         
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (gameManager.isPlaying)
        {
            transform.Translate(Vector2.left * Time.deltaTime);

            if (transform.position.x < -15)
            {
                transform.position = new Vector2(16, 0);
            }
        }

    }
}
