﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSelector : MonoBehaviour
{
	public GameObject weapon1;
	public GameObject weapon2;

	public Canvas weaponSelector;
	public Canvas PlayerHealthUI;
	public Canvas PlayerHealthUIOff;

	private bool stateBefore;

	private void Start()
	{
		weaponSelector.enabled = false;
		PlayerHealthUI.enabled = true;
		PlayerHealthUIOff.enabled = false;
	}
	private void Update()
	{
		if (GameManager.whoseTurn < GameManager.isThrowable.Length && GameManager.isThrowable[GameManager.whoseTurn] == -1 && Input.GetKeyDown("space"))
		{
			stateBefore = PlayerHealthUI.enabled;
			weaponSelector.enabled = true;
			PlayerHealthUI.enabled = false;
			PlayerHealthUIOff.enabled = false;
		}

	}

	public void selectThrow()
	{
		GameManager.isThrowable[GameManager.whoseTurn] = 0;
		weaponSelector.enabled = false;
		PlayerHealthUI.enabled = stateBefore;
		PlayerHealthUIOff.enabled = !stateBefore;
	}

	public void selectWeapon1()
	{
			GameObject wep = Instantiate(weapon1, GameManager.activePlayers[GameManager.whoseTurn].transform.position, Quaternion.identity);
			wep.GetComponent<Rigidbody2D>().isKinematic = true;
			Physics2D.IgnoreCollision(wep.GetComponent<Collider2D>(), GameManager.activePlayers[GameManager.whoseTurn].GetComponent<Collider2D>());


			GameManager.isThrowable[GameManager.whoseTurn] = 1;
			weaponSelector.enabled = false;
			PlayerHealthUI.enabled = stateBefore;
			PlayerHealthUIOff.enabled = !stateBefore;
	}

}