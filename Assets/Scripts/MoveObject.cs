using UnityEngine;
using System.Collections;

public class MoveObject : MonoBehaviour {

	public float speed = 0.1F;

	public GameObject particle;

	public	Material[] platformMats;

	void Start () {
		if (Application.platform == RuntimePlatform.WindowsEditor) {
			GetComponent<Renderer>().material = platformMats [0];
			Debug.Log ("Not mobile input.");
		}
		
		if (Application.platform == RuntimePlatform.Android){
			GetComponent<Renderer>().material = platformMats [1];
			Debug.Log ("Mobile input!");
		}
	}

	void Update() {
		if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved) {
			Vector2 touchDeltaPosition = Input.GetTouch(0).deltaPosition;
			transform.Translate(touchDeltaPosition.x * speed, touchDeltaPosition.y * speed, 0);
		}

		int i = 0;
		while (i < Input.touchCount) {
			if (Input.GetTouch(i).phase == TouchPhase.Began) {
				Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(i).position);
				if (Physics.Raycast(ray))
					Instantiate(particle, transform.position, transform.rotation); // as GameObject;
				
			}
			++i;
		}
	}


}
