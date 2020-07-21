using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Player : MonoBehaviour
{
    Rigidbody2D rb;
    public GameObject playerObj;

    GameManager gameManager;

    //int Score = 0;

    float angle = 0;
    int xSpeed = 3;
    int ySpeed = 10;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
        GetInput();
    }

    void MovePlayer() 
    {
        Vector2 pos = transform.position;
        pos.x = Mathf.Cos(angle) * 5;
        transform.position = pos;
        angle += Time.deltaTime * xSpeed;
    }

    void GetInput() 
    {

        if (Input.GetMouseButton(0))
        {
            rb.AddForce(new Vector2(0, ySpeed));
        }
        else
        {
            if (rb.velocity.y > 0)
            {
                rb.AddForce(new Vector2(0, -ySpeed));
            }
            else
            {
                rb.AddForce(new Vector2(rb.velocity.x, 0));
            }
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "DangerObject") 
        {
            Time.timeScale = 0f;
            gameManager.GameOver();
        }
        if(other.gameObject.tag == "ScoreCoin") 
        {
            gameManager.AddScore();
        }
    }
}