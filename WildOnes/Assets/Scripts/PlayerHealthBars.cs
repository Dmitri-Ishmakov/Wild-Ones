using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthBars : MonoBehaviour {

	public Slider slide1;
	public Slider slide2;
	public Slider slide3;
	public Slider slide4;

	public Canvas HealthUI;
	public Canvas HealthTurnOn;

	PlayerStats player1;
	PlayerStats player2;
	PlayerStats player3;
	PlayerStats player4;
	float play1HP;
	float play2HP;
	float play3HP;
	float play4HP;

	// Use this for initialization
	void Start () {
		HealthUI.enabled = true;
		HealthTurnOn.enabled = false;
		slide1.gameObject.SetActive(false);
		slide2.gameObject.SetActive(false);
		slide3.gameObject.SetActive(false);
		slide4.gameObject.SetActive(false);
		if (GameManager.player1)
		{
			slide1.gameObject.SetActive(true);
			player1 = GameManager.player1.GetComponent<PlayerStats>();
		}
		
		if (GameManager.player2)
		{
			slide2.gameObject.SetActive(true);
			player2 = GameManager.player2.GetComponent<PlayerStats>();
		}
		if (GameManager.player3)
		{
			slide3.gameObject.SetActive(true);
			player3 = GameManager.player3.GetComponent<PlayerStats>();
		}
		if (GameManager.player4)
		{
			slide4.gameObject.SetActive(true);
			player4 = GameManager.player4.GetComponent<PlayerStats>();
		}
	}

	private void Update()
	{
		if (GameManager.player1)
		{
			play1HP = player1.health / 100f;


			/*
			 * Change the color of the healthbar based on the amount of health left
			 * 
			 * if(play1HP <= .5 && play1HP > .25)
			 * {
			 * }
			 * if(play1HP <= .25)
			 * {
			 *
			 * }
			 */
			slide1.value = play1HP;
		}
		else
		{
			slide1.value = 0;
		}

		if (GameManager.player2)
		{
			play2HP = player2.health / 100f;
			slide2.value = play2HP;
		}
		else
		{
			slide2.value = 0;
		}

		if (GameManager.player3)
		{
			play3HP = player3.health / 100f;
			slide3.value = play3HP;
		}
		else
		{
			slide3.value = 0;
		}
		if (GameManager.player4)
		{
			play4HP = player4.health / 100f;
			slide4.value = play4HP;
		}
		else
		{
			slide4.value = 0;
		}
	}


	public void CloseHealthUI()
	{
		HealthUI.enabled = false;
		HealthTurnOn.enabled = true;
	}

	public void OpenHealthUI()
	{
		HealthUI.enabled = true;
		HealthTurnOn.enabled = false;
	}
}
