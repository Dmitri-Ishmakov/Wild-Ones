using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class EndOfGame : MonoBehaviour
{
	public GameObject player1holder;
	public GameObject player2holder;
	public GameObject player3holder;
	public GameObject player4holder;
	private GameObject[] playerHolders;

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
		playerHolders[0] = player1holder;
		playerHolders[1] = player2holder;
		playerHolders[2] = player3holder;
		playerHolders[3] = player4holder;

		for(int j = numPlayers; j < 4; j++)
		{
			Debug.Log("Should be hiding player" + j);
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
		}
	}


	public void StartNewGame()
	{
		PlayerPrefs.DeleteAll();
		SceneManager.LoadScene("CharacterSelector");
	}

}
