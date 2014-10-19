using UnityEngine;
using System.Collections;
using Leap;

public class BallMovement : MonoBehaviour {

	public int SpeedPalla = 10;
	public int BallRotationFactor = 1000;
	Controller m_leapController;
	private GUIText myGUItext;
	UnityEngine.Rect textContainer;
	public float speedFactor = 1;
	float handX;
	float handZ;


	public Transform _ballCam;

	// Use this for initialization
	void Start () {
		m_leapController = new Controller();
	}



	void OnGUI(){
		//GUI.Label(new UnityEngine.Rect(0,0,UnityEngine.Screen.width,UnityEngine.Screen.height),"ttttt");
	}	

	// Update is called once per frame
	void FixedUpdate () {
		try {
			
				
		Frame frame = m_leapController.Frame();
		Hand mainHand;
		#region leap
		if (frame.Hands.Count >= 1) 
		{
			mainHand = frame.Hands[0];

			handX = mainHand.PalmPosition.x * 0.02f * speedFactor;
			handZ = mainHand.PalmPosition.z * 0.02f * speedFactor;
			print("hand z" + handZ.ToString());
			print("hand x" + handX.ToString());
			//GUI.Label(new UnityEngine.Rect(0,0,UnityEngine.Screen.width,UnityEngine.Screen.height),"ASDASD");
			//myGUItext.text = "ASdsa";

			gameObject.rigidbody.AddForce(_ballCam.transform.right * handX );
			gameObject.rigidbody.AddTorque(-_ballCam.transform.forward * SpeedPalla * handX);

			gameObject.rigidbody.AddForce(-_ballCam.transform.forward * handZ );
			gameObject.rigidbody.AddTorque(-_ballCam.transform.right * SpeedPalla * handZ);

		}
		#endregion

		if(Input.GetButton("Vertical"))
		{
			gameObject.rigidbody.AddForce(_ballCam.transform.forward * SpeedPalla * Input.GetAxis("Vertical") * 0.8f);
			gameObject.rigidbody.AddTorque(_ballCam.transform.right * SpeedPalla * Input.GetAxis("Vertical") * 0.8f);
		}

		if(Input.GetButton("Horizontal"))
		{
			gameObject.rigidbody.AddForce(_ballCam.transform.right * SpeedPalla * Input.GetAxis("Horizontal") * 0.8f);
			gameObject.rigidbody.AddTorque(-_ballCam.transform.forward * SpeedPalla * Input.GetAxis("Horizontal")* 0.8f);
		}
		/*
		if(Input.GetKeyDown(KeyCode.Keypad6)){
			_ballCam.transform.RotateAround(_ballCam.position,Vector3.up, -90 * Time.deltaTime);
			print ("rotated!");

		}
		
		if(Input.GetKeyDown(KeyCode.Keypad4)){
			_ballCam.transform.RotateAround(_ballCam.position,Vector3.up, 90 * Time.deltaTime);
		}
		*/
		} catch (System.Exception ex) {
			
		}
	}
}

