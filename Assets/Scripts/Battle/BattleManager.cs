using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BattleManager : MonoBehaviour {

	// We need to keep track of all the combatants
	// Use 2 lists of Dictionarys

	public List<Dictionary<string, object>> TeamA = new List<Dictionary<string, object>>();

	public List<Dictionary<string, object>> TeamB = new List<Dictionary<string, object>>();

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
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
