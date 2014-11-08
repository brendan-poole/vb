using UnityEngine;
using System.Collections;

public class Lifter : MonoBehaviour {
	float StartY;
	public bool direction;

	// Use this for initialization
	void Start () {
		rigidbody.position = new Vector3 (transform.parent.position.x, transform.parent.position.y + .5f, transform.parent.position.z);
		StartY = rigidbody.position.y;
	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{
		float angle = Time.frameCount;
		if (direction) {
						angle += 180f;
				}
		float targetPosition = StartY + Mathf.Sin (angle * Mathf.Deg2Rad) * .5f;
		float diff = rigidbody.position.y - targetPosition;
		if (diff < 0) {
						rigidbody.velocity =  (new Vector3 (0, 1, 0));
				} else {
			rigidbody.velocity =  (new Vector3 (0, -1, 0));
				}
	}
}
