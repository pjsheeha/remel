using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour {

	[SerializeField]
	protected SpriteRenderer underPlatformLeft, underPlatformRight, underPlatformMid;

	protected SpriteRenderer platform;

	protected void Awake() {
		platform = GetComponent<SpriteRenderer> ();
	}

	private void SetPieceColor(SpriteRenderer sr, Color c) {

		if (sr == null) {
			return;
		}

		Material m = sr.material;

		m.color = c;
	}

	public void SetColors(Color plat, Color underLeft, Color underRight, Color underMid) {
		SetPieceColor (platform, plat);
		SetPieceColor (underPlatformLeft, underLeft);
		SetPieceColor (underPlatformMid, underRight);
		SetPieceColor (underPlatformRight, underMid);
	}

	public void SetColors(Color underLeft, Color underRight, Color underMid) {
		SetPieceColor (underPlatformLeft, underLeft);
		SetPieceColor (underPlatformMid, underMid);
		SetPieceColor (underPlatformRight, underRight);
	}

	public void SetPlatformColor(Color c) {
		SetPieceColor (platform, c);
	}

	public void SetLeftColor(Color c) {
		SetPieceColor (underPlatformLeft, c);
	}

	public void SetMidColor(Color c) {
		SetPieceColor (underPlatformMid, c);
	}

	public void SetRightColor(Color c) {
		SetPieceColor (underPlatformRight, c);
	}
}
