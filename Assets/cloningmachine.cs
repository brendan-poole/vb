using UnityEngine;
using System.Collections;

public class cloningmachine : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		GameObject s = GameObject.Find ("Sphere");
		Instantiate (s);
		s.transform.position = new Vector3 (-49f, -2f, 0f);
	}
}
