using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Weapon", menuName = "Weapon")]
public class ScriptableWeapon : ScriptableObject {
	public new string name;
	public string description;

	public int damage;
	public int fuseTime;
	public int explosionRadius;
	public int explosionForce;
	public int terrainDamage;

	public Sprite image;
	
}
