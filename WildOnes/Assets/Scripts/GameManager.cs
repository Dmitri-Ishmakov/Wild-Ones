using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
	public Canvas endOfGame;

	// Make these private and use the Active Player array to simplify accessing objects
	public static GameObject player1;
	public static GameObject player2;
	public static GameObject player3;
	public static GameObject player4;


	public static int[] isThrowable;
	/*
	 *  isThrowable will keep track of what object should be thrown:
	 *  
	 * A 0 will be the player
	 * A 1 will be weapon 1
	 * A 2 will be weapon 2
	 * etc.
	 * 
	 */

	private GameObject[] players;

	public static GameObject[] activePlayers;
	public static Vector3[,] distanceMoved;
	public static bool gameOver = false;

	public static int whoseTurn;
	public static int numPlayers;
	public static int numPlayersAlive;
	public GameObject[] turnAnnouncer;

	private float counter = 1f;
	public static int winner;



	// Use this for initialization
	void Start()
	{
		gameOver = false;
		whoseTurn = 0;
		endOfGame.enabled = false;
		numPlayers = PlayerPrefs.GetInt("numPlayers");
		isThrowable = new int[transform.childCount];
		players = new GameObject[transform.childCount];
		activePlayers = new GameObject[numPlayers];
		distanceMoved = new Vector3[numPlayers, 2];
		for (int i = 0; i < transform.childCount; i++)
		{
			players[i] = transform.GetChild(i).gameObject;
			isThrowable[i] = -1;
		}
		//set the players to their correct character model
		if (PlayerPrefs.GetInt("CharacterOne") != -1)
		{
			activePlayers[0] = player1;
		}
		if (PlayerPrefs.GetInt("CharacterTwo") != -1)
		{
			activePlayers[1] = player2;
		}
		if (PlayerPrefs.GetInt("CharacterThree") != -1)
		{
			activePlayers[2] = player3;
		}
		if (PlayerPrefs.GetInt("CharacterFour") != -1)
		{
			activePlayers[3] = player4;
		}

		numPlayersAlive = numPlayers;
		for (int i = 0; i < activePlayers.Length; i++)
		{
			distanceMoved[i, 0] = activePlayers[i].transform.position;
			distanceMoved[i, 1] = activePlayers[i].transform.position;
		}

	}

	private void Update()
	{
		counter -= Time.deltaTime;
		if (counter <= 0)
		{
			counter = 1f;
			for (int i = 0; i < activePlayers.Length; i++)
			{
				Rigidbody2D rb = activePlayers[i].GetComponent<Rigidbody2D>();
				distanceMoved[i, 0] = distanceMoved[i, 1];
				distanceMoved[i, 1] = rb.transform.position;
				if (rb != null && (distanceMoved[i, 0] - distanceMoved[i, 1]).sqrMagnitude == 0)
				{
					rb.gravityScale = 0;
					rb.rotation = 0;
				}
			}
		}
		if (!gameOver)
		{
			if (numPlayersAlive > 1)
			{
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
			else
			{
				winner = -1;
				for (int i = 0; i < activePlayers.Length; i++)
				{
					if (activePlayers[i].GetComponent<PlayerStats>().isAlive)
					{
						winner = i;
					}
				}
				numPlayersAlive = 0;
				endOfGame.enabled = true;
				gameOver = true;
			}
		}
	}
}

