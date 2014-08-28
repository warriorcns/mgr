using UnityEngine;
using System.Collections;
using Leap;

public class Menu : MonoBehaviour {

	private float y = -200;

	private int speed = 100;
	
	private float startTime;
	private int guiBoxTime = 2;
	private float handX;
	private float handZ;
	Controller m_leapController;

	//hand section
	//public LeapGameObject initialLeapObject; // Setting an initial leap object indicates a scene start in a specific state rather than default
	//public HandTypeBase handType;
	public bool isRightHand;


	// Use this for initialization
	void Start () {
		startTime = Time.time;
		m_leapController = new Controller();
	}
	
	// Update is called once per frame
	void Update () {

		Frame frame = m_leapController.Frame();
		Hand mainHand;

		if (frame.Hands.Count >= 1) 
		{
			mainHand = frame.Hands[0];



			handX = mainHand.PalmPosition.x * 0.002f;
			handZ = mainHand.PalmPosition.z * 0.002f;
			print(handX.ToString());
			//GUI.Label(new UnityEngine.Rect(0,0,UnityEngine.Screen.width,UnityEngine.Screen.height),"ASDASD");
			//myGUItext.text = "ASdsa";
			
			//gameObject.rigidbody.AddForce(Vector3.right * SpeedPalla * handX);
			//gameObject.rigidbody.AddForce(Vector3.back * SpeedPalla * handZ);

			
		}

		if (Time.time > startTime + guiBoxTime)
		{
			y += Time.deltaTime*speed;
			if (y > 50)
			{
				y = 50;
			}
		}
	}

	/*void OnGUI () {
		// Make a background box
		GUI.Box(new Rect(y,10,200,500), "Main menu");

		// Make the first button. If it is pressed, Application.Loadlevel (1) will be executed
		if(GUI.Button(new Rect(y+10,40,150,50), "NEW GAME")) {
			Application.LoadLevel(1);
		}
		
		// Make the second button.
		if(GUI.Button(new Rect(y+10,120,150,50), "OPTIONS")) {
			//Application.LoadLevel(2);
		}

		if(GUI.Button(new Rect(y+10,200,150,50), "TOP SCORES")) {
			//Application.LoadLevel(2);
		}

		if(GUI.Button(new Rect(y+10,280,150,50), "EXIT GAME")) {
			//Application.LoadLevel(2);
		}

		if(GUI.Button(new Rect(y+10,360,150,50), "CLOSE MENU")) {
			//Application.LoadLevel(2);
		}
	}*/
}
