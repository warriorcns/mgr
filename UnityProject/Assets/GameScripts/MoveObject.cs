using UnityEngine;
using System.Collections;

public class MoveObject : MonoBehaviour {
	public GameObject TriggerObject;
	public GameObject targetFirst;
	public GameObject targetSecond;
	private float smooth = 13.0f;
	private bool checkIfCollides = false;
	private bool onTriggerExit = false;
	protected Vector3 startPosition;
	protected Vector3 destination;

	// Use this for initialization
	void Start () {
		startPosition = TriggerObject.transform.localPosition;
		/*recognize element 
		* plate in floor -> move down by 0.2f
		* button in wall -> move to wall direction by 0.2f //WIP
		*/
		switch(TriggerObject.tag){
			case "plate":
				destination = new Vector3(0f,-0.2f,0f) + TriggerObject.transform.localPosition;
				break;

			case "buttonPlusX":
				break;

			case "buttonMinusX":
				break;

			case "buttonPlusZ":
				break;

			case "buttonMinusZ":
				break;

			default:
				break;
		}	

	}
	
	// Update is called once per frame
	void Update () {
		//source.transform.position(1,1,1);
		if(checkIfCollides){
			TriggerObject.transform.localPosition = Vector3.Lerp (TriggerObject.transform.localPosition, destination, Time.deltaTime * smooth);

		}else if(onTriggerExit){
			TriggerObject.transform.localPosition = Vector3.Lerp (TriggerObject.transform.localPosition, startPosition, Time.deltaTime * smooth);
		}
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

				if(targetFirst) {
					targetFirst.transform.Translate(Vector3.right * Time.deltaTime);
				}
				if(targetSecond){
					targetSecond.transform.Translate(Vector3.right * Time.deltaTime);
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
