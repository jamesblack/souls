using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

public class Unit : MonoBehaviour {

	public UnitStats Stats;
	public Text HealthIndicator;
	public Text TurnChargeIndicator;
	public float TurnCharge;

	void Awake() {
		Stats = new UnitStats ();
	}

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		HealthIndicator.text = Stats.HpCurrent.ToString ();
		TurnChargeIndicator.text = Math.Floor(TurnCharge).ToString ();
	}

	public void Attack(Unit target) {
		target.Damage (Stats.RawAtk);
	}

	public void Damage(int damage) {
		Stats.HpCurrent -= damage - Stats.RawDef;
	}
}
