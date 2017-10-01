using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour {


		//Drag in the Bullet Emitter from the Component Inspector.
		public GameObject Bullet_Emitter;
		public GameObject Bullet_EmitterL;

		//Drag in the Bullet Prefab from the Component Inspector.
		public GameObject Bullet;

		//Enter the Speed of the Bullet from the Component Inspector.
		public float Bullet_Forward_Force;

		// Use this for initialization
		void Start ()
		{

		}

		// Update is called once per frame
		void Update ()
		{
			if (Input.GetKeyDown("d"))
			{
				//The Bullet instantiation happens here.
				GameObject Temporary_Bullet_Handler;
				Temporary_Bullet_Handler = Instantiate(Bullet,Bullet_Emitter.transform.position,Bullet_Emitter.transform.rotation) as GameObject;



				//Retrieve the Rigidbody component from the instantiated Bullet and control it.
				Rigidbody Temporary_RigidBody;
				Temporary_RigidBody = Temporary_Bullet_Handler.GetComponent<Rigidbody>();

				//Tell the bullet to be "pushed" forward by an amount set by Bullet_Forward_Force.
				Temporary_RigidBody.AddForce(transform.right * Bullet_Forward_Force);

				//Basic Clean Up, set the Bullets to self destruct after 10 Seconds, I am being VERY generous here, normally 3 seconds is plenty.
				Destroy(Temporary_Bullet_Handler, 5.0f);
			}
			if (
				Input.GetKeyDown("a"))
			{
				//The Bullet instantiation happens here.
				GameObject Temporary_Bullet_Handler;
				Temporary_Bullet_Handler = Instantiate(Bullet,Bullet_EmitterL.transform.position,Bullet_EmitterL.transform.rotation) as GameObject;



				//Retrieve the Rigidbody component from the instantiated Bullet and control it.
				Rigidbody Temporary_RigidBody;
				Temporary_RigidBody = Temporary_Bullet_Handler.GetComponent<Rigidbody>();

				//Tell the bullet to be "pushed" forward by an amount set by Bullet_Forward_Force.
				Temporary_RigidBody.AddForce(-1* transform.right * Bullet_Forward_Force);

				//Basic Clean Up, set the Bullets to self destruct after 10 Seconds, I am being VERY generous here, normally 3 seconds is plenty.
				Destroy(Temporary_Bullet_Handler, 5.0f);
			}
			if (Input.GetKey(KeyCode.W))
				transform.Translate(Vector3.up * Time.deltaTime * 12f);
		}
	}
