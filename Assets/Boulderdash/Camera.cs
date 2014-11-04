using UnityEngine;
using System.Collections;

public class Camera : MonoBehaviour {

	GameObject guy;

	// Use this for initialization
	void Start () {
		guy = GameObject.Find("Guy");
	}
	
	void Update () {

		transform.LookAt (guy.transform);
		transform.position = guy.transform.position;
		transform.position += new Vector3 (0, 0, -20);

		RaycastHit hitInfo = new RaycastHit ();
		bool hit = Physics.Raycast (UnityEngine.Camera.main.ScreenPointToRay (Input.mousePosition), out hitInfo);
		if (hit && Input.GetKey(KeyCode.Mouse0) && hitInfo.transform.gameObject.tag.StartsWith( "Earth")) {
			GameObject.Destroy(hitInfo.transform.gameObject);
			Debug.Log(hitInfo.point);
		}
	}
}
