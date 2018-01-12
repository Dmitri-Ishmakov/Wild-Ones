using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponThrow : MonoBehaviour
{

	//This will be used to let us interact with our player only
	//when the mouse is pressed down
	private bool isPressed = false;

	//this will keep track of if the turn has been taken
	public bool hasThrown = false;
	private bool hasGrabbed = false;

	
	public int maxDistance;
	private Vector2 heading;
	private Vector3 maxPoint;
	private float currentDistance;

	public Rigidbody2D rb;
	public float releaseTime = .15f;
	private PlayerStats player;
	private int whoseTurn;

	private void OnMouseDown()
	{
		Debug.Log("I Have Actual Clicked This");
		whoseTurn = GameManager.whoseTurn;
		if (GameManager.isThrowable[whoseTurn] == 1)
		{
			isPressed = true;
			hasGrabbed = true;
			player = GameManager.activePlayers[whoseTurn].GetComponent<PlayerStats>();
		}
	}

	
	private void OnMouseUp()
	{
		if (hasGrabbed)
		{
			hasThrown = true;
			hasGrabbed = false;
			rb.isKinematic = false;
			rb.AddForce(heading * currentDistance*2, ForceMode2D.Impulse);
			StartCoroutine(Stall(.5f));
			StartCoroutine(Wait(2));
		}
	}


	private void Update()
	{
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
		for (int i = 0; i < GameManager.isThrowable.Length; i++) {
			GameManager.isThrowable[i] = -1;
		}
		GameManager.whoseTurn++;
		isPressed = false;
	}


	IEnumerator Stall(float time)
	{
		yield return new WaitForSeconds(time);
		foreach (GameObject go in GameManager.activePlayers)
		{
			Physics2D.IgnoreCollision(this.GetComponent<Collider2D>(), go.GetComponent<Collider2D>(), false);
		}
	}
	IEnumerator Wait(int time)
	{
		yield return new WaitForSeconds(time);
		increment();
	}
}

