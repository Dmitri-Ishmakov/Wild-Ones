using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StatsShower : MonoBehaviour {
	public ScriptablePlayer player;

	public GameObject jumpPower;
	public GameObject throwPower;
	public GameObject HP;


	private void Start()
	{
		jumpPower.GetComponent<TextMeshProUGUI>().text = player.jumpPower.ToString();
		throwPower.GetComponent<TextMeshProUGUI>().text = player.throwPower.ToString();
		HP.GetComponent<TextMeshProUGUI>().text = player.health.ToString();
	}

}
