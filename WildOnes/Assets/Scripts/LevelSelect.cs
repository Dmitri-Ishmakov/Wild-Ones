using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelect : MonoBehaviour {
	private void Start()
	{
		PlayerPrefs.DeleteAll();
	}
	public void SelectLevelOne()
	{
		PlayerPrefs.SetString("Level Selected", "Main Game");
		SceneManager.LoadScene("CharacterSelector");
	}
}
