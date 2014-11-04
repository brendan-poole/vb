using UnityEngine;
using System.Collections;

public class Roller : MonoBehaviour {

	public float velocity;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		rigidbody.angularVelocity = new Vector3 (0f, 0f, velocity);
	}
}
