using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Weapon : MonoBehaviour
{
	public ScriptableWeapon weap;
	public SpriteRenderer render;

	[HideInInspector]
	public int fuseLength;
	[HideInInspector]
	public int explosionRadius;
	[HideInInspector]
	public int explosionStrength;
	[HideInInspector]
	public int damage;
	private float fuseLeft;
	[HideInInspector]
	public int intFuseLeft;


	//use this to keep track of the text and change it when its an int
	[HideInInspector]
	public float counter = 0;
	[HideInInspector]
	public int intCounter = 0;

	//Player distance Info
	private float[] players;



	// Use this for initialization
	void Start()
	{
		players = new float[4];
		fuseLength = weap.fuseTime;
		explosionRadius = weap.explosionRadius;
		explosionStrength = weap.explosionForce;
		damage = weap.damage;
		render.sprite = weap.image;
		render.sortingLayerName = "Weapon";

		fuseLeft = fuseLength;
		intFuseLeft = fuseLength - 1;
	}

	// Update is called once per frame
	void Update()
	{

		if (this.GetComponent<WeaponThrow>().hasThrown)
		{
			fuseLeft -= Time.deltaTime;
			counter += Time.deltaTime;
			intCounter = (int)counter;
			if (intCounter == 1)
			{
				intFuseLeft = (int)fuseLeft;
				intCounter = 0;
				counter = 0;
			}
		}
		if (fuseLeft < 0)
		{
			Explode(damage);
		}
	}

	public void Explode(int damage)
	{
		Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, explosionRadius);

		foreach(Collider2D nearbyObject in colliders){
			Rigidbody2D rb = nearbyObject.GetComponent<Rigidbody2D>();
			if(rb != null && rb.tag == "Player")
			{
				rb.gravityScale = 1;
				rb.AddForce((rb.transform.position - transform.position).normalized
					* ((1 / (rb.transform.position - transform.position).magnitude) * explosionStrength), ForceMode2D.Impulse);
				rb.GetComponent<PlayerStats>().TakeDamage(damage);
			}
		}



		Destroy(gameObject);
	}
}
