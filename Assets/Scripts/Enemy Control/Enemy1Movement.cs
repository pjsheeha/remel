using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1Movement : EnemyMovement
{
    public float jumpHeight = 4.0f;
    public int numJumps = 5;
    public float h_Input;
    public int remainingJumps;
    private Vector2 newPosition;
    public bool isGrounded;

	public float directionMultiplier = 1f;

    // Use this for initialization
    protected override void Start()
    {
        base.Start();
        //remainingJumps = numJumps;
    }

    // Update is called once per frame
    protected override void Update()
    {
        HorizontalMovement();
    }

    protected override void DefaultBehavior()
    {

    }

//********************************

    private void HorizontalMovement()
    {
        //h_Input = enemyManager.useMovement ? Input.GetAxis("Horizontal") : 0f;
        h_Input = Input.GetAxis("Horizontal");

        // use rigidbody position instead of transform to eliminate jitter when colliding with walls
        //enemyManager.rb.position += Vector2.right * h_Input * Time.deltaTime * moveSpeed;
		Vector2 toNewPosition = Vector2.left * h_Input * Time.deltaTime * moveSpeed * directionMultiplier;
        newPosition = enemyManager.rb.position + toNewPosition;

        enemyManager.rb.position += toNewPosition;
        //enemyManager.rb.position += Vector2.left * h_Input * Time.deltaTime * moveSpeed;
        /*
        enemyManager.SetAnimation("walk", Mathf.Abs(h_Input) > 0f);

        enemyManager.spriteRenderer.flipX = h_Input != 0f ? (h_Input > 0f ? false : true) : enemyManager.spriteRenderer.flipX;
    */
    }
    
}
