using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterSelection : MonoBehaviour
{
	public Canvas charSelector;
	public Canvas numPlayers;
	public GameObject playerColor;

	private GameObject[] characterList;
	private GameObject[] playerColorList;
	private int indexChar1;
	private int indexChar2;
	private int indexChar3;
	private int indexChar4;
	private int index;
	private int numChar;
	private int charsSelected;

	private int[,] selectedChars;

	private int colorIndex;
	private Color[] colorList;

	// Use this for initialization
	void Start()
	{
		PlayerPrefs.DeleteAll();
		indexChar1 = -1;
		indexChar2 = -1;
		indexChar3 = -1;
		indexChar4 = -1;
		index = 0;
		charsSelected = 1;
		characterList = new GameObject[transform.childCount];

		colorList = new Color[3];
		colorIndex = 0;
		colorList[0] = Color.white;
		colorList[1] = Color.red;
		colorList[2] = Color.blue;

		//Get the list of player colors and go ahead and turn them all off
		playerColorList = new GameObject[playerColor.transform.childCount];

		for (int i = 0; i < playerColorList.Length; i++)
		{
			playerColorList[i] = playerColor.transform.GetChild(i).gameObject;
			playerColorList[i].SetActive(false);
		}


		//fill our array
		for (int i = 0; i < transform.childCount; i++)
		{
			characterList[i] = transform.GetChild(i).gameObject;
			characterList[i].SetActive(false);
		}
		charSelector.enabled = false;

	}

	public void toggleLeft()
	{
		//Toggle off current model
		characterList[index].SetActive(false);

		index--;
		if (index < 0)
		{
			index = characterList.Length - 1;
		}

		//Toggle on the new index
		characterList[index].SetActive(true);
		colorIndex = 0;
	}

	public void toggleRight()
	{
		//Toggle off current model
		characterList[index].SetActive(false);

		index++;
		if (index > characterList.Length - 1)
		{
			index = 0;
		}

		//Toggle on the new index
		characterList[index].SetActive(true);
		colorIndex = 0;
	}

	public void toggleUp()
	{


		colorIndex++;
		for (int i = 0; i < charsSelected; i++)
		{
			if (colorIndex > colorList.Length - 1)
			{
				colorIndex = 0;
			}
			if (selectedChars[i, 0] == index && selectedChars[i, 1] == colorIndex)
			{
				colorIndex++;
			}
		}

		characterList[index].GetComponent<SpriteRenderer>().color = colorList[colorIndex];
	}

	public void toggleDown()
	{
		colorIndex--;
		for (int i = 0; i < charsSelected; i++)
		{
			if (selectedChars[i, 0] == index && selectedChars[i, 1] == colorIndex && colorIndex != -1)
			{
				colorIndex--;
			}
			if (colorIndex < 0)
			{
				colorIndex = colorList.Length - 1;
			}
		}

		characterList[index].GetComponent<SpriteRenderer>().color = colorList[colorIndex];
	}

	public void setOne()
	{
		index = 0;
		PlayerPrefs.SetInt("numPlayers", 1);
		PlayerPrefs.SetInt("CharacterTwo", -1);
		PlayerPrefs.SetInt("CharacterThree", -1);
		PlayerPrefs.SetInt("CharacterFour", -1);
		numChar = 1;
		charSelector.enabled = true;
		numPlayers.enabled = false;
		//toggle on the rederer
		if (characterList[index])
		{
			characterList[index].SetActive(true);
		}
		for (int i = 0; i < 1; i++)
		{
			playerColorList[i].SetActive(true);
		}
		selectedChars = new int[numChar, 2];
		for (int i = 0; i < selectedChars.Length; i++)
		{
			selectedChars[i, 0] = -1;
			selectedChars[i, 1] = -1;
		}
	}

	public void setTwo()
	{
		index = 0;
		PlayerPrefs.SetInt("numPlayers", 2);
		PlayerPrefs.SetInt("CharacterThree", -1);
		PlayerPrefs.SetInt("CharacterFour", -1);
		numChar = 2;
		charSelector.enabled = true;
		numPlayers.enabled = false;
		//toggle on the rederer
		if (characterList[index])
		{
			characterList[index].SetActive(true);
		}
		for (int i = 0; i < 2; i++)
		{
			playerColorList[i].SetActive(true);
		}
		selectedChars = new int[numChar, 2];
		/*
		for (int i = 0; i < selectedChars.Length; i++)
		{
			selectedChars[i, 0] = -1;
			selectedChars[i, 1] = -1;
		}
		*/
	}

	public void setThree()
	{
		index = 0;
		PlayerPrefs.SetInt("numPlayers", 3);
		PlayerPrefs.SetInt("CharacterFour", -1);
		numChar = 3;
		charSelector.enabled = true;
		numPlayers.enabled = false;
		//toggle on the rederer
		if (characterList[index])
		{
			characterList[index].SetActive(true);
		}
		for (int i = 0; i < 3; i++)
		{
			playerColorList[i].SetActive(true);
		}
		selectedChars = new int[numChar, 2];
		for (int i = 0; i < selectedChars.Length; i++)
		{
			selectedChars[i, 0] = -1;
			selectedChars[i, 1] = -1;
		}
	}

	public void SetFour()
	{
		index = 0;
		numChar = 4;
		PlayerPrefs.SetInt("numPlayers", 4);
		charSelector.enabled = true;
		numPlayers.enabled = false;
		//toggle on the rederer
		if (characterList[index])
		{
			characterList[index].SetActive(true);
		}
		for (int i = 0; i < 4; i++)
		{
			playerColorList[i].SetActive(true);
		}
		selectedChars = new int[numChar, 2];
		for (int i = 0; i < selectedChars.Length; i++)
		{
			selectedChars[i, 0] = -1;
			selectedChars[i, 1] = -1;
		}
	}

	public void whoStays()
	{
		if (indexChar1 >= 0)
		{
			characterList[indexChar1].SetActive(true);
		}
		if (indexChar2 >= 0)
		{
			characterList[indexChar2].SetActive(true);
		}
		if (indexChar3 >= 0)
		{
			characterList[indexChar3].SetActive(true);
		}
		if (indexChar4 >= 0)
		{
			characterList[indexChar4].SetActive(true);
		}
	}

	public void confirmButton()
	{

		if (charsSelected <= numChar)
		{
			if (charsSelected == 1)
			{
				PlayerPrefs.SetInt("CharacterOne", index);
				PlayerPrefs.SetInt("CharacterOneColor", colorIndex);
				playerColorList[0].GetComponent<SpriteRenderer>().sprite = characterList[index].GetComponent<SpriteRenderer>().sprite;
				playerColorList[0].GetComponent<SpriteRenderer>().color = characterList[index].GetComponent<SpriteRenderer>().color;
				selectedChars[0, 0] = index;
				selectedChars[0, 1] = colorIndex;

			}
			else if (charsSelected == 2)
			{
				PlayerPrefs.SetInt("CharacterTwo", index);
				PlayerPrefs.SetInt("CharacterTwoColor", colorIndex);
				playerColorList[1].GetComponent<SpriteRenderer>().sprite = characterList[index].GetComponent<SpriteRenderer>().sprite;
				playerColorList[1].GetComponent<SpriteRenderer>().color = characterList[index].GetComponent<SpriteRenderer>().color;

				selectedChars[1, 0] = index;
				selectedChars[1, 1] = colorIndex;
			}
			else if (charsSelected == 3)
			{
				PlayerPrefs.SetInt("CharacterThree", index);
				PlayerPrefs.SetInt("CharacterThreeColor", colorIndex);
				playerColorList[2].GetComponent<SpriteRenderer>().sprite = characterList[index].GetComponent<SpriteRenderer>().sprite;
				playerColorList[2].GetComponent<SpriteRenderer>().color = characterList[index].GetComponent<SpriteRenderer>().color;

				selectedChars[2, 0] = index;
				selectedChars[2, 1] = colorIndex;
			}
			else if (charsSelected == 4)
			{
				PlayerPrefs.SetInt("CharacterFour", index);
				PlayerPrefs.SetInt("CharacterFourColor", colorIndex);
				playerColorList[3].GetComponent<SpriteRenderer>().sprite = characterList[index].GetComponent<SpriteRenderer>().sprite;
				playerColorList[3].GetComponent<SpriteRenderer>().color = characterList[index].GetComponent<SpriteRenderer>().color;

				selectedChars[3, 0] = index;
				selectedChars[3, 1] = colorIndex;
			}
			charsSelected++;
		}

		if (charsSelected > numChar)
		{
			SceneManager.LoadScene("Main Game");
		}

	}
}
