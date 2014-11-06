using UnityEngine;
using System.Collections;

public class Lifter : MonoBehaviour {
	float StartY;
	public bool direction;
	float frame = 0;
	// Use this for initialization
	void Start () {
		StartY = rigidbody.position.y;
		if (direction) {
			frame += 180f;
		}
	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{
		float targetPosition = StartY + Mathf.Sin (frame * Mathf.Deg2Rad) * 2.1f;
		float diff = rigidbody.position.y - targetPosition;
		if (diff < 0) {
						rigidbody.velocity =  (new Vector3 (0, 1, 0));
				} else {
			rigidbody.velocity =  (new Vector3 (0, -1, 0));
				}
		frame += .5f;
	}
}
