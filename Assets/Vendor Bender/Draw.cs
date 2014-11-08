using UnityEngine;
using System.Collections;

public class Draw : MonoBehaviour {

	GameController game;
	GameObject roller;
	GameObject antiRoller;
	GameObject monkey;
	GameObject block;
	GameObject grog;
	GameObject lifter;
	bool lifterDirection;


	// Use this for initialization
	void Start () {
		game = (GameController)GameObject.Find ("GameController").GetComponent ("GameController");
		roller = GameObject.Find ("Roller");
		monkey = GameObject.Find ("Monkey");
		antiRoller = GameObject.Find ("AntiRoller");
		block = GameObject.Find ("Block");
		grog = GameObject.Find ("Grog");
		lifter = GameObject.Find ("Lifter");
	}
	
	// Update is called once per frame
	void Update () {
		RaycastHit hitInfo = new RaycastHit ();
		Ray ray = UnityEngine.Camera.main.ScreenPointToRay (Input.mousePosition);
		bool hit = Physics.Raycast (ray, out hitInfo);
		float x = hitInfo.point.x;
		float y = hitInfo.point.y;
		Vector3 newPosition = new Vector3 (x - x % .5f, y - y % .5f, -.5f);
		if (hit && Input.GetKey(KeyCode.Mouse0) && !Physics.CheckSphere (newPosition, .1f) && 
		    hitInfo.transform.gameObject.tag.StartsWith ("Board")) {
			if (game.CurrentTool == Tool.Roller) {
				Instantiate (roller, newPosition, roller.transform.rotation);
			} else if (game.CurrentTool == Tool.AntiRoller) {
				Instantiate (antiRoller, newPosition, antiRoller.transform.rotation);
			} else if (game.CurrentTool == Tool.Monkey) {
				Instantiate (monkey, newPosition, roller.transform.rotation);
			} else if (game.CurrentTool == Tool.Block) {
				Instantiate (block, newPosition, block.transform.rotation);
			} else if (game.CurrentTool == Tool.Grog) {
				Instantiate (grog, newPosition, grog.transform.rotation);
			} else if (game.CurrentTool == Tool.Lifter) {
				GameObject newLifter = (GameObject)Instantiate (lifter, newPosition, lifter.transform.rotation);
				((Lifter)newLifter.transform.Find("Cube.003").GetComponent("Lifter")).direction = lifterDirection;

				if(lifterDirection) {
					((Lifter)newLifter.transform.Find("Cube.003").GetComponent("Lifter")).renderer.material.color = Color.blue;
				} else {
					((Lifter)newLifter.transform.Find("Cube.003").GetComponent("Lifter")).renderer.material.color = Color.red;
				}
				lifterDirection = !lifterDirection;
			}
		}
		if (hit && Input.GetKey (KeyCode.Mouse0) && game.CurrentTool == Tool.Clear
		    && !hitInfo.transform.gameObject.tag.Equals("Button")
		    && hitInfo.rigidbody != null) {
			Debug.Log (hitInfo.rigidbody.gameObject.name);
			Destroy(hitInfo.rigidbody.gameObject);
		}
	}
}
