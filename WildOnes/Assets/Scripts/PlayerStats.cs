using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
	public SpriteRenderer rend;
	public ScriptablePlayer play;
	public Rigidbody2D rb;
	[HideInInspector]
	public float jumpPower;
	[HideInInspector]
	public float throwPower;
	[HideInInspector]
	public bool canFly;
	[HideInInspector]
	public bool isAlive = true;
	[HideInInspector]
	public int health = 10;
	[HideInInspector]
	public int damageDealt = 0;
	[HideInInspector]
	public int kills = 0;



	//public GameObject deathEffect;
	private void Start()
	{
		jumpPower = play.jumpPower;
		throwPower = play.throwPower;
		canFly = play.canFly;
		rend.sprite = play.Image;
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{

		rb.gravityScale = 1;
		Rigidbody2D temp = collision.gameObject.GetComponent<Rigidbody2D>();
		if (temp != null)
		{

			temp.gravityScale = 1;
		}
	}

	public void TakeDamage(int amount)
	{
		health -= amount;

		if (health <= 0)
		{
			Die();
		}
	}

	void Die()
	{

		/* need to add some sort of effect which causes them to pop or something
		essentially just some way to make them die, not simply disappear
		*/
		gameObject.SetActive(false);
		isAlive = false;
		GameManager.numPlayersAlive--;

	}
}
