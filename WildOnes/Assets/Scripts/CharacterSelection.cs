using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterSelection : MonoBehaviour
{
	public Canvas charSelector;
	public Canvas numPlayers;

	private GameObject[] characterList;
	private int indexChar1 = -1;
	private int indexChar2 = -1;
	private int indexChar3 = -1;
	private int indexChar4 = -1;
	private int index = 0;
	private int numChar;
	private int charsSelected = 1;
	private int integerBoolean = 0;

	// Use this for initialization
	void Start()
	{

		//create the array that will hold our character models
		characterList = new GameObject[transform.childCount];

		//fill our array
		for (int i = 0; i < transform.childCount; i++)
		{
			characterList[i] = transform.GetChild(i).gameObject;
			//toggle off their renderer
			characterList[i].SetActive(false);
		}
		//Turn off the char selector because I'm dumb and don't know how to default it to off
		charSelector.enabled = false;

		if(PlayerPrefs.GetInt("integerBoolean") == 1)
		{
			integerBoolean = PlayerPrefs.GetInt("integerBoolean");
		}

		//So if I am in the real game
		if (integerBoolean == 1)
		{
			indexChar1 = PlayerPrefs.GetInt("CharacterOne");
			indexChar2 = PlayerPrefs.GetInt("CharacterTwo");
			indexChar3 = PlayerPrefs.GetInt("CharacterThree");
			indexChar4 = PlayerPrefs.GetInt("CharacterFour");
			
			whoStays();
			PlayerPrefs.SetInt("integerBoolean", 0);
		}
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
			}
			if (charsSelected == 2)
			{
				PlayerPrefs.SetInt("CharacterTwo", index);
			}
			if (charsSelected == 3)
			{
				PlayerPrefs.SetInt("CharacterThree", index);
			}
			if (charsSelected == 4)
			{
				PlayerPrefs.SetInt("CharacterFour", index);
			}
			charsSelected++;
		}

		if(charsSelected > numChar)
		{
			PlayerPrefs.SetInt("integerBoolean", 1);
			SceneManager.LoadScene("Main Game");
		}

	}
}
