using UnityEngine;
using System.Collections;

public class Teleport : MonoBehaviour {

	public Transform playerObject;
	public Transform spawn;
	private bool checkIfCollides = false;
	private bool onTriggerExit = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider col){
		
		if(col.tag == "Player"){
			checkIfCollides = true;
			onTriggerExit = false;
		}
	}
	
	void OnTriggerStay(Collider col)
	{
		if(col.tag == "Player"){
			if(checkIfCollides){
				
				if(playerObject && spawn) {
					playerObject.transform.position = spawn.transform.position;
				}

			}
		}
	}
	void OnTriggerExit(Collider col){
		if(col.tag == "Player"){
			checkIfCollides = false;
			onTriggerExit = true;
		}
	}
}
