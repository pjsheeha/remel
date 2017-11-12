#pragma strict

function Start () {
}

function Update () {
	var vec = Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
	transform.position += vec * 2 * Time.deltaTime;

}

function OnCollisonEnter(collision: Collision){
	Debug.Log("asdfadsfasdFadsf");
}