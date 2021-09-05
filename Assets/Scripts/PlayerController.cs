using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerController : MonoBehaviour
{
    public float speed = 4.0f;
    public float jumpForce = 5.0f;
    private bool moving = true;
    float t = 0.0f;
    private Rigidbody2D playerRb;
    private int count = 0;
    public bool isPlaying = true;
    public Instances instances;
    private bool check = true;
    void Awake()
    {
        playerRb = GetComponent<Rigidbody2D>();
    }

    void MoveForward()
    {
        transform.position += transform.right * speed * Time.deltaTime;
        if (instances.PlayerRT && Math.Round(instances.PlayerRT.anchoredPosition.x % 1920) == 0 && check) { check = false; Debug.Log("Generate " + instances.PlayerRT.anchoredPosition.x); instances.generator.GeneratePlatforms(); }
        else
        {
            check = true;
        }
    }
    public void Jump()
    {
        playerRb.velocity = new Vector2(playerRb.velocity.x, jumpForce);
        moving = false;
        t = 0.0f;
        if (moving)
        {
            // Record the time spent moving up or down.
            // When this is 1sec then display info
            t += Time.deltaTime;
            if (t > 1.0f)
            {
                t = 0.0f;
            }
        }
        count++;
    }
    void OnCollisionEnter2D(Collision2D coll)
    {
        if (playerRb.velocity.y < 0.01f) // default platform
        {
            count = 0;
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (count < 2)
            {
                Jump();
            }
        }
        MoveForward();
    }
}
