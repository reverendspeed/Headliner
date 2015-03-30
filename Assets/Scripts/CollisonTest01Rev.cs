using UnityEngine;
using System.Collections;

public class CollisonTest01Rev : MonoBehaviour {

	void OnTriggerStay(Collider other){
		if (other.gameObject.CompareTag ("TestSphere")) {
			Debug.Log ("Baboo!");
		}
	}
}
