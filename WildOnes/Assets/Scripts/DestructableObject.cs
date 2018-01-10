using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestructableObject : MonoBehaviour {
	public GameObject[] Images;
	private int health;
	private int damageTaken = 0;


	// Use this for initialization
	void Start () {
		health = transform.childCount + 1;
		Images = new GameObject[health];
		Images[0] = transform.gameObject;
		for(int i = 1; i < health; i++)
		{
			Images[i] = transform.GetChild(i - 1).gameObject;
		}
	}
	
	public void Damage(int damage)
	{
		damageTaken += damage;
		if(damageTaken < health)
		{
			transform.GetComponent<SpriteRenderer>().sprite = Images[damageTaken].GetComponent<SpriteRenderer>().sprite;
			transform.GetComponent<SpriteRenderer>().color = Images[damageTaken].GetComponent<SpriteRenderer>().color;
		}
		else{
			Destroy(transform.gameObject);
		}
	}
}
