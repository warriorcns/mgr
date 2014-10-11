using UnityEngine;
using System.Collections;

public class SmoothIsometricFollow : MonoBehaviour {


	public Transform target;
	public float heightDamping = 2;

	private  float currentPosX;
	private  float currentPosY;
	private  float currentPosZ;

	protected int camera_velocity = 20;
	private float wantedHeight;
	private float height = 5;
	private float currentHeight;

	private float wantedPosX = 0;
	private float wantedPosY = 4;
	private float wantedPosZ = -5;


	// Use this for initialization
	void Start () {


	}
	
	// Update is called once per frame
	void FixedUpdate () {

		if (!target)
			return;

		currentPosX = target.position.x + wantedPosX;
		currentPosY = target.position.y + wantedPosY;
		currentPosZ = target.position.z + wantedPosZ;

		transform.position = new Vector3(currentPosX, currentPosY, currentPosZ);

		transform.LookAt (target);
	}
}
