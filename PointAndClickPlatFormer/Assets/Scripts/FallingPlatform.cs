using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlatform : MonoBehaviour
{

    Rigidbody2D rgdBody;
    float TimeLeft = 1.0f;
    bool playerIsOn = false;

    void Start()
    {
        rgdBody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (playerIsOn) TimeLeft -= Time.deltaTime;
        if (TimeLeft <= 0) rgdBody.bodyType = RigidbodyType2D.Dynamic;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            playerIsOn = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        playerIsOn = false;
    }
}
