using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyeballMovement : EnemyMovement {

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
        base.Update();
    }

    protected override void DefaultBehavior()
    {
        base.DefaultBehavior();
    }

    protected bool facingPlayer()
    {
        PlayerManager pm = PlayerManager.Instance;

        Vector2 pDir = pm.spriteRenderer.flipX ? Vector2.left : Vector2.right;
        Vector2 eDir = enemyManager.sr.flipX ? Vector2.left : Vector2.right;
        //Vector2 eDir = enemyManager.transform.right * enemyManager.spriteRenderer.flipX ? -1f : 1f;
        Vector2 pPos = pm.rb.position;
        Vector2 ePos = enemyManager.rb.position;

        if (ePos.x < pPos.x && eDir.x > pDir.x)
            return true;
        else if (ePos.x > pPos.x && eDir.x < pDir.x)
            return true;
        else
            return false;
    }


}
