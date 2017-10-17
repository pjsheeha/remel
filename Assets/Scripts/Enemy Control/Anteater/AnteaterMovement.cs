using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnteaterMovement : EnemyMovement {

	// Use this for initialization
	protected override void Start () {
		base.Start ();
		enemyManager.onDetection += ChaseFootPrint;
	}

	// Update is called once per frame
	protected override void Update () {
		base.Update ();
	}

	protected override void DefaultBehavior ()
	{
		base.DefaultBehavior ();
	}

	protected void ChaseFootPrint() {
		print ("chase!");
	}

}
