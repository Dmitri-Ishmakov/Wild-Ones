using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSelector : MonoBehaviour
{
	public GameObject weapon1;
	public GameObject weapon2;

	public Canvas weaponSelector;
	public Canvas PlayerHealthUI;
	public Canvas PlayerHealthUIOff;

	private bool stateBefore;


	private void Update()
	{
		if (Input.GetKeyDown("space") && GameManager.isThrowable[GameManager.whoseTurn] == -1)
		{
			stateBefore = PlayerHealthUI.enabled;
			weaponSelector.enabled = true;
			PlayerHealthUI.enabled = false;
			PlayerHealthUIOff.enabled = false;
		}

	}

	public void selectThrow()
	{
		GameManager.isThrowable[GameManager.whoseTurn] = 0;
		weaponSelector.enabled = false;
		PlayerHealthUI.enabled = stateBefore;
		PlayerHealthUIOff.enabled = !stateBefore;
	}

	public void selectWeapon1()
	{
		if (GameManager.whoseTurn == 0)
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

		GameManager.isThrowable[GameManager.whoseTurn] = 1;
		weaponSelector.enabled = false;
		PlayerHealthUI.enabled = stateBefore;
		PlayerHealthUIOff.enabled = !stateBefore;
	}
}
