using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyeballManager : EnemyManager {

	protected override void Animate() {
		SetAnim ("moving", isMoving);
	}
}
