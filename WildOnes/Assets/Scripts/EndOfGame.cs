using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class EndOfGame : MonoBehaviour
{
	public GameObject player1Holder;
	public GameObject player2Holder;
	public GameObject player3Holder;
	public GameObject player4Holder;
	private GameObject[] playerHolders;

	public GameObject player1Kills;
	public GameObject player2Kills;
	public GameObject player3Kills;
	public GameObject player4Kills;
	private GameObject[] playerKills;

	public Image player1;
	public Image player2;
	public Image player3;
	public Image player4;

	private Image[] players;
	private int numPlayers;


	public GameObject player1Dmg;
	public GameObject player2Dmg;
	public GameObject player3Dmg;
	public GameObject player4Dmg;

	private GameObject[] playersDmg;
	private bool hasUpdated = false;

	private void Start()
	{
		numPlayers = GameManager.numPlayers;

		players = new Image[4];
		players[0] = player1;
		players[1] = player2;
		players[2] = player3;
		players[3] = player4;

		playersDmg = new GameObject[4];
		playersDmg[0] = player1Dmg;
		playersDmg[1] = player2Dmg;
		playersDmg[2] = player3Dmg;
		playersDmg[3] = player4Dmg;

		playerHolders = new GameObject[4];
		playerHolders[0] = player1Holder;
		playerHolders[1] = player2Holder;
		playerHolders[2] = player3Holder;
		playerHolders[3] = player4Holder;

		playerKills = new GameObject[4];
		playerKills[0] = player1Kills;
		playerKills[1] = player2Kills;
		playerKills[2] = player3Kills;
		playerKills[3] = player4Kills;

		for(int j = numPlayers; j < 4; j++)
		{
			playerHolders[j].SetActive(false);
		}


		
		for (int i = 0; i < numPlayers; i++)
		{
			players[i].sprite = GameManager.activePlayers[i].GetComponent<SpriteRenderer>().sprite;
		}


		player1.sprite = players[0].sprite;
		player2.sprite = players[1].sprite;
		player3.sprite = players[2].sprite;
		player4.sprite = players[3].sprite;
	}


	private void Update()
	{
		if (!hasUpdated && GameManager.gameOver)
		{
			for (int i = 0; i < GameManager.activePlayers.Length; i++)
			{
				playersDmg[i].GetComponent<TextMeshProUGUI>().text = GameManager.activePlayers[i].GetComponent<PlayerStats>().damageDealt.ToString();
			}
			for (int k = 0; k < numPlayers; k++)
			{
				playerKills[k].GetComponent<TextMeshProUGUI>().text = GameManager.activePlayers[k].GetComponent<PlayerStats>().kills.ToString();
			}
		}
	}


	public void StartNewGame()
	{
		SceneManager.LoadScene("CharacterSelector");
	}

}
