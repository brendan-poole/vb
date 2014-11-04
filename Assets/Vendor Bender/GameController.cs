using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

	public Tool CurrentTool;

	// Use this for initialization
	void Start () {
		CurrentTool = Tool.Roller;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Mouse0)) {
			RaycastHit hitInfo = new RaycastHit ();
			Ray ray = UnityEngine.Camera.main.ScreenPointToRay (Input.mousePosition);
			bool hit = Physics.Raycast (ray, out hitInfo);
			if(hitInfo.rigidbody != null) {
				if(hitInfo.rigidbody.name.Equals("ClearButton")) {
					CurrentTool = Tool.Clear;
				} else if(hitInfo.rigidbody.name.Equals("RollerButton")) {
					CurrentTool = Tool.Roller;
				} else if(hitInfo.rigidbody.name.Equals("AntiRollerButton")) {
					CurrentTool = Tool.AntiRoller;
				} else if(hitInfo.rigidbody.name.Equals("MonkeyButton")) {
					CurrentTool = Tool.Monkey;
				} else if(hitInfo.rigidbody.name.Equals("BlockButton")) {
					CurrentTool = Tool.Block;
				} else if(hitInfo.rigidbody.name.Equals("GrogButton")) {
					CurrentTool = Tool.Grog;
				}
			}
		}
	}

}
