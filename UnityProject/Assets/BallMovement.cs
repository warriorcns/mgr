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

	// Use this for initialization
	void Start () {
		m_leapController = new Controller();
	}



	void OnGUI(){
		GUI.Label(new UnityEngine.Rect(0,0,UnityEngine.Screen.width,UnityEngine.Screen.height),"ttttt");
	}
	// Update is called once per frame
	void FixedUpdate () {
		Frame frame = m_leapController.Frame();
		Hand mainHand;

		if (frame.Hands.Count >= 1) 
		{
			mainHand = frame.Hands[0];

			handX = mainHand.PalmPosition.x * 0.002f * speedFactor;
			handZ = mainHand.PalmPosition.z * 0.002f * speedFactor;
			print(handZ.ToString());
			//GUI.Label(new UnityEngine.Rect(0,0,UnityEngine.Screen.width,UnityEngine.Screen.height),"ASDASD");
			//myGUItext.text = "ASdsa";

			gameObject.rigidbody.AddForce(Vector3.right * SpeedPalla * handX);
			gameObject.rigidbody.AddForce(Vector3.back * SpeedPalla * handZ);

		}


		if(Input.GetButton("Vertical"))
		{
			gameObject.rigidbody.AddForce(Vector3.forward * SpeedPalla * Input.GetAxis("Vertical"));
		}

		if(Input.GetButton("Horizontal"))
		{
			gameObject.rigidbody.AddForce(Vector3.left * SpeedPalla);
		}

	}
}

