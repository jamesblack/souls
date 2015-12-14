using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class BattleManager : MonoBehaviour {

	// We need to keep track of all the combatants
	// Use 2 lists of Dictionarys

	public List<GameObject> TeamA = new List<GameObject>();

	public List<GameObject> TeamB = new List<GameObject>();

	public int Turn;

	public Queue Queue = new Queue();

	// Use this for initialization
	void Start () {
		foreach (Transform team in transform) {
			foreach ( Transform unit in team ) {
				GameObject unitObject = unit.gameObject;
				// This is where we would grab the script of the unit.
				if (team.name == "TeamA") {
					TeamA.Add(unitObject);
				} else if(team.name == "TeamB") {
					TeamB.Add(unitObject);
				}
			}
		}

		TeamA [0].GetComponent<Unit> ().Stats.RawSpd = 2;

		Turn = 0;
	}
	
	// Update is called once per frame
	void Update () {
		// Check if anyone has a turn ready, if not increment their charge.

		if (Queue.Count > 0) {
			return;
		}

		foreach (GameObject unit in TeamA) {
			unit.GetComponent<Unit>().TurnCharge += (unit.GetComponent<Unit>().Stats.RawSpd  * Time.deltaTime);

			if (unit.GetComponent<Unit>().TurnCharge >= 100) {
				Queue.Enqueue(unit);
			}
		}

		foreach (GameObject unit in TeamB) {
			unit.GetComponent<Unit>().TurnCharge += unit.GetComponent<Unit>().Stats.RawSpd * Time.deltaTime;

			if (unit.GetComponent<Unit>().TurnCharge >= 100) {
				Queue.Enqueue(unit);
			}
		}
	}
}
