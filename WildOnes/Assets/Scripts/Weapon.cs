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
	[HideInInspector]
	public int terrainDamage;
	[HideInInspector]
	public GameObject explosion;
	[HideInInspector]
	public int whoThrew;


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
		explosion = weap.explosion;
		players = new float[4];
		fuseLength = weap.fuseTime;
		explosionRadius = weap.explosionRadius;
		explosionStrength = weap.explosionForce;
		damage = weap.damage;
		render.sprite = weap.image;
		render.sortingLayerName = "Weapon";
		terrainDamage = weap.terrainDamage;

		whoThrew = GameManager.whoseTurn;

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
		GameObject cloneExplosion = Instantiate(explosion, transform.position, transform.rotation);
		PlayerStats activePlayer = GameManager.activePlayers[whoThrew].GetComponent<PlayerStats>();

		foreach(Collider2D nearbyObject in colliders){
			Rigidbody2D rb = nearbyObject.GetComponent<Rigidbody2D>();
			DestructableObject destr = nearbyObject.GetComponent<DestructableObject>();
			if(rb != null && rb.tag == "Player")
			{
				rb.gravityScale = 1;
				rb.AddForce((rb.transform.position - transform.position).normalized
					* ((1 / (rb.transform.position - transform.position).magnitude) * explosionStrength), ForceMode2D.Impulse);
				rb.GetComponent<PlayerStats>().TakeDamage(damage);
				activePlayer.damageDealt += damage;
				if(rb.GetComponent<PlayerStats>().health <= 0)
				{
					activePlayer.kills++;
				}
			}
			if(destr != null)
			{
				destr.Damage(terrainDamage);
			}
		}



		Destroy(gameObject);
		Destroy(cloneExplosion);
	}
}
