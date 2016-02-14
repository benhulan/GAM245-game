using UnityEngine;
using System.Collections;

public class HideCardsOnCircle : MonoBehaviour {

	// Use this for initialization
	void Start () {
	   GetComponent<Renderer>().enabled = false;
	}
	
}
