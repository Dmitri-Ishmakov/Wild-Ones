using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerTurnIndicator : MonoBehaviour {
	public GameObject player1;
	public GameObject player2;
	public GameObject player3;
	public GameObject player4;
	public GameObject turnIndicator;

	private GameObject[] icons;
	// Use this for initialization
	void Start () {
		icons = new GameObject[4]; 
		icons[0] = player1;
		icons[1] = player2;
		icons[2] = player3;
		icons[3] = player4;

		for(int i = 0; i < GameManager.numPlayers; i++)
		{
			icons[i].GetComponent<Image>().sprite = GameManager.activePlayers[i].GetComponent<SpriteRenderer>().sprite;
		}
	}

	void Update()
	{
		turnIndicator.transform.position = icons[GameManager.whoseTurn].transform.position;
	}
}
