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
	private float wantedPosY = 5;
	private float wantedPosZ = -5;

	private GameObject to;


	// Use this for initialization
	void Start () {
		to = new GameObject();
	}




	void Update()
	{
		if (!target)
			return;
		//transform.RotateAround(target.position,Vector3.up, -90 * Time.deltaTime);


	}
	
	// Update is called once per frame
	void FixedUpdate () {

		if (!target)
			return;
		currentPosX = target.position.x + wantedPosX;
		currentPosY = target.position.y + wantedPosY;
		currentPosZ = target.position.z + wantedPosZ;

		to.transform.position = new Vector3(currentPosX, currentPosY, currentPosZ);

		if(Input.GetKeyDown(KeyCode.Keypad6)){

			if(wantedPosZ != 0 && wantedPosZ < 0){
				wantedPosZ = 0f;
				wantedPosX = 5f;
			}else if(wantedPosX != 0 && wantedPosX > 0){ 
				wantedPosZ = 5f;
				wantedPosX = 0f;
			}else if(wantedPosZ != 0 && wantedPosZ > 0){
				wantedPosZ = 0f;
				wantedPosX = -5f;
			}else if(wantedPosX != 0 && wantedPosX < 0){
				wantedPosZ = -5f;
				wantedPosX = 0f;
			}

		}

		if(Input.GetKeyDown(KeyCode.Keypad4)){

			if(wantedPosZ != 0 && wantedPosZ < 0){
				wantedPosZ = 0f;
				wantedPosX = -5f;
			}else if(wantedPosX != 0 && wantedPosX < 0){ 
				wantedPosZ = 5f;
				wantedPosX = 0f;
			}else if(wantedPosZ != 0 && wantedPosZ > 0){
				wantedPosZ = 0f;
				wantedPosX = 5f;
			}else if(wantedPosX != 0 && wantedPosX > 0){
				wantedPosZ = -5f;
				wantedPosX = 0f;
			}
		}
		transform.position = Vector3.Lerp(transform.position, to.transform.position, Time.deltaTime * 2f);

		transform.LookAt (target);

	}

}
