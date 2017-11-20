using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyeballMovement : EnemyMovement {

	private float h_Input;

    // Use this for initialization
    protected override void Start()
    {
        base.Start();
    }
    
    // Update is called once per frame
    protected override void Update()
    {
        /*if (facingPlayer()) {
            moveSpeed = 8f;
        }
        else
        {
            moveSpeed = 6f;
        }*/
        // base.Update();

		h_Input = Input.GetAxis ("Horizontal");

		float currentspeed = facingPlayer() ? moveSpeed : idleSpeed;
		enemyManager.rb.position -= h_Input * Vector2.right * currentspeed * Time.deltaTime;

		enemyManager.anim.speed = currentspeed / idleSpeed;

		if (h_Input != 0f) {
			enemyManager.sr.flipX = enemyManager.SpriteLeftByDefault ? (h_Input < 0f) : (h_Input > 0f);
			isMoving = true;
		} else {
			isMoving = false;
		}
    }

    protected override void DefaultBehavior()
    {
        // base.DefaultBehavior();
    }

    protected bool facingPlayer()
    {
        PlayerManager pm = PlayerManager.Instance;

		Vector2 dir = (enemyManager.sr.flipX ? Vector2.right : Vector2.left) * (enemyManager.SpriteLeftByDefault ? 1f : -1f);
        //Vector2 eDir = enemyManager.transform.right * enemyManager.spriteRenderer.flipX ? -1f : 1f;
        Vector2 pPos = pm.rb.position;
        Vector2 ePos = enemyManager.rb.position;

		Vector2 EToP = pPos - ePos;

		if (Mathf.Sign (EToP.x) == Mathf.Sign (dir.x)) {
			return true;
		}

		return false;

        /*if (ePos.x < pPos.x && eDir.x > pDir.x)
            return true;
        else if (ePos.x > pPos.x && eDir.x < pDir.x)
            return true;
        else
           return false;*/
    }


}
