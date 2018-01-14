using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthBars : MonoBehaviour {

	// This needs updated to hold these values in array's so I can access them through references to the 
	// Active player array

	public Color initialColor;
	public Color midHPColor;
	public Color lowHPColor;

	public Slider slide1;
	public GameObject fill1;

	public Slider slide2;
	public GameObject fill2;

	public Slider slide3;
	public GameObject fill3;

	public Slider slide4;
	public GameObject fill4;

	private Slider[] slides;
	private GameObject[] fills;

	public Canvas HealthUI;
	public Canvas HealthTurnOn;

	private PlayerStats player1;
	private PlayerStats player2;
	private PlayerStats player3;
	private PlayerStats player4;
	private PlayerStats[] playerstats;

	
	private float play1HP;
	private float play2HP;
	private float play3HP;
	private float play4HP;
	private float[] playHP;
	

	private GameObject[] actives = new GameObject[4];
	private int numPlayers;

	// Use this for initialization
	void Start () {
		for(int i = 0; i < GameManager.activePlayers.Length; i++)
		{
			actives[i] = GameManager.activePlayers[i];
		}
		numPlayers = GameManager.numPlayers;

		slides = new Slider[4];
		slides[0] = slide1;
		slides[1] = slide2;
		slides[2] = slide3;
		slides[3] = slide4;

		fills = new GameObject[4];
		fills[0] = fill1;
		fills[1] = fill2;
		fills[2] = fill3;
		fills[3] = fill4;

		playHP = new float[4];
		playHP[0] = play1HP;
		playHP[1] = play2HP;
		playHP[2] = play3HP;
		playHP[3] = play4HP;

		playerstats = new PlayerStats[4];
		playerstats[0] = player1;
		playerstats[1] = player2;
		playerstats[2] = player3;
		playerstats[3] = player4;

		HealthUI.enabled = true;
		HealthTurnOn.enabled = false;
		slide1.gameObject.SetActive(false);
		slide2.gameObject.SetActive(false);
		slide3.gameObject.SetActive(false);
		slide4.gameObject.SetActive(false);

		for(int i = 0; i < numPlayers; i++)
		{
			playerstats[i] = actives[i].GetComponent<PlayerStats>();
			slides[i].gameObject.SetActive(true);
		}
	}



	private void Update()
	{
		for (int i = 0; i < numPlayers; i ++){
			playHP[i] = playerstats[i].health / 100f;

			if(playHP[i] <= .5 && playHP[i] > .25)
			{
				fills[i].GetComponent<Image>().color = midHPColor;
			}
			else if (playHP[i] <= .25)
			{
				fills[i].GetComponent<Image>().color = lowHPColor;
			}
			slides[i].value = playHP[i];
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
