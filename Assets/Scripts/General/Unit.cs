using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

public class Unit : MonoBehaviour {

	public UnitStats Stats;
	public Text HealthIndicator;

	// Use this for initialization
	void Start () {
		Stats = new UnitStats ();
	}
	
	// Update is called once per frame
	void Update () {
		HealthIndicator.text = Stats.HpCurrent.ToString ();
	}

	public void Attack(Unit target) {
		target.Damage (Stats.RawAtk);
	}

	public void Damage(int damage) {
		Stats.HpCurrent -= damage - Stats.RawDef;
	}
}
