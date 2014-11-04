using UnityEngine;
using System.Collections;
 
public class Bucket : MonoBehaviour {
	public float speed = 500f;
	public float lastSqrMag;
	public Vector3 desiredVelocity;
	public Vector3 touchPosition;

	void start() {
		touchPosition = Vector3.zero;
	}

	void Update () {
		if(Input.GetKeyDown(KeyCode.Mouse0)) {
			float x = Input.mousePosition.x;
			float y = Input.mousePosition.y;
			touchPosition = UnityEngine.Camera.main.ScreenToWorldPoint(new Vector3(x, y, 10));
			Vector3 directionalVector = (touchPosition - transform.position).normalized * speed;
			desiredVelocity = directionalVector;
			lastSqrMag = Mathf.Infinity;
		}
		float sqrMag = (touchPosition - transform.position).sqrMagnitude;
		if ( sqrMag > lastSqrMag ) {
			desiredVelocity = Vector3.zero;
		} 
		lastSqrMag = sqrMag;
	}
	void FixedUpdate() {
		rigidbody2D.velocity = desiredVelocity;
	}
}
 