using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
	public Canvas endOfGame;

	public static GameObject player1;
	public static GameObject player2;
	public static GameObject player3;
	public static GameObject player4;

	public static int[] isThrowable;
	// isThrowable will keep track of what object should be thrown. 
	// A 0 will be the player
	// A 1 will be weapon 1
	// A 2 will be weapon 2
	// etc.

	private GameObject[] players;

	public static GameObject[] activePlayers;

	public static int whoseTurnLast = 0;
	public static int whoseTurn = 0;
	public static int numPlayers;
	public static int numPlayersAlive;
	public GameObject[] turnAnnouncer;



	// Use this for initialization
	void Start()
	{
		endOfGame.enabled = false;
		numPlayers = PlayerPrefs.GetInt("numPlayers");
		isThrowable = new int[transform.childCount];
		players = new GameObject[transform.childCount];
		activePlayers = new GameObject[numPlayers];
		for (int i = 0; i < transform.childCount; i++)
		{
			players[i] = transform.GetChild(i).gameObject;
			isThrowable[i] = -1;
		}
		//set the players to their correct character model
		if (PlayerPrefs.GetInt("CharacterOne") != -1)
		{
			player1 = players[PlayerPrefs.GetInt("CharacterOne")];
			activePlayers[0] = player1;
		}
		if (PlayerPrefs.GetInt("CharacterTwo") != -1)
		{
			player2 = players[PlayerPrefs.GetInt("CharacterTwo")];
			activePlayers[1] = player2;
		}
		if (PlayerPrefs.GetInt("CharacterThree") != -1)
		{
			player3 = players[PlayerPrefs.GetInt("CharacterThree")];
			activePlayers[2] = player3;
		}
		if (PlayerPrefs.GetInt("CharacterFour") != -1)
		{
			player4 = players[PlayerPrefs.GetInt("CharacterFour")];
			activePlayers[3] = player4;
		}

		numPlayersAlive = numPlayers;

	}

	private void Update()
	{
		if (numPlayersAlive > 0)
		{
			if (numPlayersAlive == 1)
			{
				numPlayersAlive = 0;
				endOfGame.enabled = true;
				Debug.Log("Game Over");
			}

			if (whoseTurn > numPlayers - 1)
			{
				whoseTurn = 0;
			}
			PlayerStats play = activePlayers[whoseTurn].GetComponent<PlayerStats>();
			if (!play.isAlive)
			{
				whoseTurn++;
			}
		}
	}
}

