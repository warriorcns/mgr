using UnityEngine;
using System.Collections;

public class MoveObject : MonoBehaviour {
	public GameObject plate;
	public GameObject targetFirst;
	public GameObject targetSecond;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		//source.transform.position(1,1,1);



	}

	void OnTriggerEnter(Collider col){
	
	}

	void OnTriggerStay(Collider other)
	{

		if(plate){
			//plate must move not more that 0.1 units down
			float Y = plate.transform.localPosition.y;

			//plate.transform.Translate(0,startPoint * Time.deltaTime,0);
			//Vector3 targetPosition = new Vector3(plate.transform.localPosition.x, Y + 0.1f, plate.transform.localPosition.z);
			//plate.transform.localPosition = Vector3.MoveTowards(plate.transform.localPosition, targetPosition, 0.01f * Time.deltaTime);
			//plate.transform.localPosition = targetPosition;
			plate.transform.Translate(Vector3.up * Time.deltaTime);

		}
		if(targetFirst) {
			targetFirst.transform.Translate(Vector3.right * Time.deltaTime);
		}
		if(targetSecond){
			targetSecond.transform.Translate(Vector3.right * Time.deltaTime);
		}
	
	}

}
