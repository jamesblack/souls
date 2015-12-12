using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class BattleManager : MonoBehaviour {

	// We need to keep track of all the combatants
	// Use 2 lists of Dictionarys

	public List<Dictionary<string, object>> TeamA = new List<Dictionary<string, object>>();

	public List<Dictionary<string, object>> TeamB = new List<Dictionary<string, object>>();

	public int Turn;

	public Text TurnIndicator;

	// Use this for initialization
	void Start () {
		foreach (Transform team in transform) {
			foreach ( Transform unit in team ) {
				GameObject unitObject = unit.gameObject;
				// This is where we would grab the script of the unit.
				if (team.name == "TeamA") {
					TeamA.Add(new Dictionary<string, object>() {
						{ "object", unitObject }
					});
				} else if(team.name == "TeamB") {
					TeamB.Add(new Dictionary<string, object>() {
						{ "object", unitObject }
					});
				}
			}
		}

		Turn = 0;
		TurnIndicator.text = "0";
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown (0)) {
			RaycastHit hit;
			var ray = Camera.main.ScreenPointToRay(Input.mousePosition);

			if (Physics.Raycast(ray, out hit)) {
				Debug.Log (hit.transform.parent.transform.name);
				((GameObject)TeamA[0]["object"]).GetComponent<Unit>().Attack(hit.transform.parent.GetComponent<Unit>());
			}
		}
	}
}
