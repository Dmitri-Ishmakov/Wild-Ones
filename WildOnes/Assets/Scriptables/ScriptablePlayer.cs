using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Player", menuName = "Player")]
public class ScriptablePlayer : ScriptableObject {

	public new string name;
	public string description;

	public Sprite Image;

	public int health;
	public float jumpPower;
	public float throwPower;
	public bool canFly;


}
