using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1Manager : EnemyManager {
    private float h_Input;
    Enemy1Movement movement;

    protected override void Animate()
    {
        h_Input = Input.GetAxis("Horizontal");

        base.Animate();
        bool isMoving = h_Input != 0f;
        SetAnim("walking", isMoving);
        SetAnim("moving", isMoving);

        //sr.flipX = enemyMovement.Displacement.x > 0f ? (spriteLeftByDefault ? true : false) : (spriteLeftByDefault ? false : true);
        //sr.flipX = h_Input != 0f ? (h_Input > 0f ? false : true) : sr.flipX;
        sr.flipX = h_Input != 0f ? (h_Input > 0f ? false : true) : (h_Input > 0f ? true : false);
        /*
        if (Input.GetKeyDown(KeyCode.UpArrow) && movement.remainingJumps > 0)
        {
            SetAnim("grounded", false);
            if (movement.isGrounded)
            {
                TriggerAnim("jump");
            }
            else
            {
                TriggerAnim("air_jump");
            }
        }
        */

    }
    /*
    private bool isGrounded {
        return movement.isGrounded;
    }
    */
}
