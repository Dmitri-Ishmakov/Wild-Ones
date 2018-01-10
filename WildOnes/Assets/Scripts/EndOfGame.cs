using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndOfGame : MonoBehaviour {
	public void StartNewGame()
	{
		PlayerPrefs.DeleteAll();
		SceneManager.LoadScene("CharacterSelector");
	}


}
