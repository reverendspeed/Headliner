using UnityEngine;
using System.Collections;

public class Dragger : MonoBehaviour {

	private	bool	isAndroid = false;

	public	Camera	conversationCamera;

	private Vector3	startingPosition;

	private	Transform	clampMax;
	private	Transform	clampMin;

	// Use this for initialization
	void Start () {
	
		if (Application.platform == RuntimePlatform.Android) {
			isAndroid = true;
		} else {
			isAndroid = false;
		}

		startingPosition = transform.position - conversationCamera.transform.position;

		clampMax = GameObject.Find ("ClampMax").GetComponent<Transform> ();
		clampMin = GameObject.Find ("ClampMin").GetComponent<Transform> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (isAndroid) {
			InputAndr();
		} else {
			InputEdit();
		}
	}

	void InputAndr(){
		Vector3	tempPosition = conversationCamera.ScreenToWorldPoint (new Vector3 (Input.touches[0].position.x,
			                                                                       Input.touches[0].position.y,
			                                                                       startingPosition.z));
		transform.position = new Vector3 (startingPosition.x, 
		                                  Mathf.Clamp(tempPosition.y, clampMin.position.y, clampMax.position.y),
		                                  tempPosition.z); 
	}

	void InputEdit(){
		Vector3	tempPosition = conversationCamera.ScreenToWorldPoint (new Vector3 (Input.mousePosition.x,
				                                                                   Input.mousePosition.y,
				                                                                   startingPosition.z));
		transform.position = new Vector3 (startingPosition.x, 
		                                  Mathf.Clamp(tempPosition.y, clampMin.position.y, clampMax.position.y),
		                                  tempPosition.z);
	}
}
