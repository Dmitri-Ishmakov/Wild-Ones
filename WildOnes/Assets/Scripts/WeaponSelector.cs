using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSelector : MonoBehaviour {
	public GameObject weapon1;
	public GameObject weapon2;
	public Canvas weaponSelector;


	public void OnMouseDown()
	{
		//if it is player 1's turn && nothing is selected for them to do set the weaponSelector to the other one
		if(GameManager.whoseTurn == 0 && GameManager.isThrowable[0] == -1 && this.transform.position == GameManager.player1.transform.position)
		{
			weaponSelector.transform.position = GameManager.player1.transform.position;
			weaponSelector.enabled = true;
		}
		else if (GameManager.whoseTurn == 1 && GameManager.isThrowable[1] == -1 && this.transform.position == GameManager.player2.transform.position)
		{
			weaponSelector.transform.position = GameManager.player2.transform.position;
			weaponSelector.enabled = true;
		}
		else if (GameManager.whoseTurn == 2 && GameManager.isThrowable[2] == -1 && this.transform.position == GameManager.player3.transform.position)
		{
			weaponSelector.transform.position = GameManager.player3.transform.position;
			weaponSelector.enabled = true;
		}
		else if (GameManager.whoseTurn == 3 && GameManager.isThrowable[3] == -1 && this.transform.position == GameManager.player4.transform.position)
		{
			weaponSelector.transform.position = GameManager.player4.transform.position;
			weaponSelector.enabled = true;
		}
	}

	public void selectThrow()
	{
		GameManager.isThrowable[GameManager.whoseTurn] = 0;
		weaponSelector.enabled = false;
	}

	public void selectWeapon1()
	{
		if(GameManager.whoseTurn == 0)
		{
			GameObject wep = Instantiate(weapon1, GameManager.player1.transform.position, Quaternion.identity);
			wep.GetComponent<Rigidbody2D>().isKinematic = true;
			Physics2D.IgnoreCollision(wep.GetComponent<Collider2D>(), GameManager.player1.GetComponent<Collider2D>());
		}
		else if (GameManager.whoseTurn == 1)
		{
			GameObject wep = Instantiate(weapon1, GameManager.player2.transform.position, Quaternion.identity);
			wep.GetComponent<Rigidbody2D>().isKinematic = true;
			Physics2D.IgnoreCollision(wep.GetComponent<Collider2D>(), GameManager.player2.GetComponent<Collider2D>());
		}
		else if (GameManager.whoseTurn == 2)
		{
			GameObject wep = Instantiate(weapon1, GameManager.player3.transform.position, Quaternion.identity);
			wep.GetComponent<Rigidbody2D>().isKinematic = true;
			Physics2D.IgnoreCollision(wep.GetComponent<Collider2D>(), GameManager.player3.GetComponent<Collider2D>());
		}
		else if (GameManager.whoseTurn == 3)
		{
			GameObject wep = Instantiate(weapon1, GameManager.player4.transform.position, Quaternion.identity);
			wep.GetComponent<Rigidbody2D>().isKinematic = true;
			Physics2D.IgnoreCollision(wep.GetComponent<Collider2D>(), GameManager.player4.GetComponent<Collider2D>());
		}
		
		GameManager.isThrowable[GameManager.whoseTurn ] = 1;
		weaponSelector.enabled = false;
	}
}
