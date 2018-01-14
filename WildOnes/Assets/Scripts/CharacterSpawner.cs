using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSpawner : MonoBehaviour {
	private int indexChar1;
	private int indexChar2;
	private int indexChar3;
	private int indexChar4;

	public GameObject spawn1;
	public GameObject spawn2;
	public GameObject spawn3;
	public GameObject spawn4;

	private Color[] colorList;

	// Use this for initialization
	void Start () {
		colorList = new Color[3];
		colorList[0] = Color.white;
		colorList[1] = Color.red;
		colorList[2] = Color.blue;

		for (int i = 0; i < transform.childCount; i++)
		{
			transform.GetChild(i).gameObject.SetActive(false);
		}
		indexChar1 = PlayerPrefs.GetInt("CharacterOne");
		indexChar2 = PlayerPrefs.GetInt("CharacterTwo");
		indexChar3 = PlayerPrefs.GetInt("CharacterThree");
		indexChar4 = PlayerPrefs.GetInt("CharacterFour");

		if (indexChar1 != -1)
		{
			GameManager.player1 = Instantiate(transform.GetChild(indexChar1).gameObject, spawn1.transform.position, Quaternion.identity);
			GameManager.player1.GetComponent<SpriteRenderer>().color = colorList[PlayerPrefs.GetInt("CharacterOneColor")];
			GameManager.player1.SetActive(true);
		}
		if (indexChar2 != -1)
		{
			GameManager.player2 = Instantiate(transform.GetChild(indexChar2).gameObject, spawn2.transform.position, Quaternion.identity);
			GameManager.player2.GetComponent<SpriteRenderer>().color = colorList[PlayerPrefs.GetInt("CharacterTwoColor")];
			GameManager.player2.SetActive(true);
		}
		if (indexChar3 != -1)
		{
			GameManager.player3 = Instantiate(transform.GetChild(indexChar3).gameObject, spawn3.transform.position, Quaternion.identity);
			GameManager.player3.GetComponent<SpriteRenderer>().color = colorList[PlayerPrefs.GetInt("CharacterThreeColor")];
			GameManager.player3.SetActive(true);
		}
		if (indexChar4 != -1)
		{
			GameManager.player4 = Instantiate(transform.GetChild(indexChar4).gameObject, spawn4.transform.position, Quaternion.identity);
			GameManager.player4.GetComponent<SpriteRenderer>().color = colorList[PlayerPrefs.GetInt("CharacterFourColor")];
			GameManager.player4.SetActive(true);
		}
	}
}
