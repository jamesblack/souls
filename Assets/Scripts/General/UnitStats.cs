using UnityEngine;
using System.Collections;
using System;

[Serializable]
public class UnitStats {

	public int Level;
	public int HpMax;
	public int HpCurrent;

	public int RawAtk;
	public int RawDef;
	public int RawSpd;

	public UnitStats() {
		Level = 1;
		HpMax = 10;
		HpCurrent = 10;

		RawAtk = 1;
		RawDef = 1;
		RawSpd = 1;
	}
}
