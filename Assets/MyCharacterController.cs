using UnityEngine;
using System.Collections;

public class MyCharacterController : MonoBehaviour {
	
	public float inputDelay=0.1f;
	public float forwardVel=12;
	public float rotateVel=100;
	Quaternion targetRotation;
	Rigidbody rigidBody;

	float forwardInput=0,turnInput=0;

	public Quaternion TargetRotation{
		get{return targetRotation;}
	}

	void Start(){
		targetRotation = transform.rotation;
		rigidBody = GetComponent<Rigidbody> ();
	}

	void GetInput(){
		forwardInput = Input.GetAxis ("Vertical");
		turnInput = Input.GetAxis ("Horizontal");
	}

	void Update(){

		GetInput ();
		Turn ();
	}

	void FixedUpdate(){
		Run ();
	}

	void Run(){
		if (Mathf.Abs (forwardInput) > inputDelay) {
			rigidBody.velocity = transform.forward*forwardInput*forwardVel;
		} else
			rigidBody.velocity = Vector3.zero;
	}

	void Turn(){
		targetRotation *= Quaternion.AngleAxis (rotateVel * turnInput * Time.deltaTime, Vector3.up);
		transform.rotation = targetRotation;
	}
}
