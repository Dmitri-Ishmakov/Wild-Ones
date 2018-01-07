using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Throw : MonoBehaviour {

	//This will be used to let us interact with our player only
	//when the mouse is pressed down
	private bool isPressed = false;
	private bool isThrowing = false;

	//this will keep track of if the turn has been taken
	private bool hasThrown = false;
	private bool hasGrabbed = false;


	private Vector2 currentPoint;
	private Vector2 startingPoint;
	public int maxDistance;
	private Vector2 heading;
	private Vector3 maxPoint;
	private float currentDistance;


	public float releaseTime = .15f;
	public Rigidbody2D rb;
	public GameObject anchor;

	private void Start()
	{
		startingPoint = rb.position;
		currentPoint = rb.position;
	}

	private void OnMouseDown()
	{
		if (GameManager.whoseTurn == 1 && rb.position.x == GameManager.player1.transform.position.x)
		{
			isPressed = true;
			rb.isKinematic = true;
			hasGrabbed = true;
		}
		else if (GameManager.whoseTurn == 2 && rb.position.x == GameManager.player2.transform.position.x)
		{
			isPressed = true;
			rb.isKinematic = true;
			hasGrabbed = true;

		}
		else if (GameManager.whoseTurn == 3 && rb.position.x == GameManager.player3.transform.position.x)
		{
			isPressed = true;
			rb.isKinematic = true;
			hasGrabbed = true;
		}
		else if (GameManager.whoseTurn == 4 && rb.position.x == GameManager.player4.transform.position.x)
		{
			isPressed = true;
			rb.isKinematic = true;
			hasGrabbed = true;

		}
	}

	private void OnMouseUp()
	{
		isPressed = false;
		rb.isKinematic = false;

		StartCoroutine(Release());
		if (hasGrabbed)
		{
			hasThrown = true;
			hasGrabbed = false;
		}
	}

	private void Update()
	{
		startingPoint = currentPoint;
		currentPoint = rb.position;

		if (currentPoint.x - startingPoint.x < .01 && currentPoint.x - startingPoint.x > -.01)
		{
			GetComponent<SpringJoint2D>().enabled = true;
			if (hasThrown)
			{
				increment();
			}
		}

		if (isPressed)
		{
			rb.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			heading.x = anchor.transform.position.x - rb.position.x;
			heading.y = anchor.transform.position.y - rb.position.y;
			currentDistance = heading.magnitude;
			
			if (currentDistance > maxDistance)
			{
				heading = -heading.normalized * maxDistance;

				maxPoint.x = anchor.transform.position.x + heading.x;
				maxPoint.y = anchor.transform.position.y + heading.y;
				maxPoint.z = 0;
				rb.position = maxPoint;		
			}
		}
		else if(!isPressed && !isThrowing)
		{
			anchor.transform.position = rb.position;
		}
	}

	IEnumerator Release()
	{
		isThrowing = true;
		yield return new WaitForSeconds(releaseTime);
		isThrowing = false;
		GetComponent<SpringJoint2D>().enabled = false;

	}

	private void increment()
	{
		GameManager.whoseTurn++;
		hasThrown = false;
	}
}
