using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponTimer : MonoBehaviour {

	public Image visual;
	public Text timer;


	private int timervalue;

	// Update is called once per frame
	void Update()
	{
		if (GetComponent<Weapon>()) { 
		timervalue = GetComponent<Weapon>().intFuseLeft + 1;
		timer.text = timervalue.ToString();
		visual.fillAmount = GetComponent<Weapon>().counter;
	}
	}
}
