using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowWithImpulse : MonoBehaviour
{

	//This will be used to let us interact with our player only
	//when the mouse is pressed down
	private bool isPressed = false;

	//this will keep track of if the turn has been taken
	private bool hasThrown = false;
	private bool hasGrabbed = false;

	public int maxDistance;
	private Vector2 heading;
	private Vector3 maxPoint;
	private Vector3 initialPos;
	private float currentDistance;

	public float releaseTime = .15f;
	public Rigidbody2D rb;

	private PlayerStats player;
	private Rigidbody2D activePlayer;
	private int whoseTurn;
	
	private void OnMouseDown()
	{
		whoseTurn = GameManager.whoseTurn;
		if (GameManager.isThrowable[whoseTurn] == 0)
		{
			if (rb.position.x == GameManager.activePlayers[whoseTurn].transform.position.x)
			{
				activePlayer = GameManager.activePlayers[whoseTurn].GetComponent<Rigidbody2D>();
				player = GameManager.activePlayers[whoseTurn].GetComponent<PlayerStats>();
				isPressed = true;
				hasGrabbed = true;
			}
		}
	}

	private void OnMouseUp()
	{
		if (hasGrabbed)
		{
			if (heading.sqrMagnitude > .5)
			{
				hasThrown = true;
				rb.gravityScale = 1;
				activePlayer.AddForce(heading * currentDistance * player.jumpPower, ForceMode2D.Impulse);
				increment();
				
			}
			else
			{
				hasGrabbed = false;
			}
		}
	}
	
	private void Update()
	{
		if (hasThrown && player.canFly && Input.GetKeyDown("space"))
		{
			activePlayer.AddForce(Vector2.up * 10, ForceMode2D.Impulse);
		}
		
		if (isPressed)
		{
			heading.x = -Camera.main.ScreenToWorldPoint(Input.mousePosition).x + rb.position.x;
			heading.y = -Camera.main.ScreenToWorldPoint(Input.mousePosition).y + rb.position.y;
			currentDistance = heading.magnitude;

			if (currentDistance > maxDistance)
			{
				heading = heading.normalized * maxDistance;
				currentDistance = maxDistance;
			}
		}

		}


	private void increment()
	{
		StartCoroutine(wait(2));
	}

	IEnumerator wait(int time)
	{
		GameManager.isThrowable[whoseTurn] = -2;
		hasGrabbed = false;
		isPressed = false;
		yield return new WaitForSecondsRealtime(time);
		GameManager.isThrowable[whoseTurn] = -1;
		GameManager.whoseTurn++;
		hasThrown = false;

	}
}