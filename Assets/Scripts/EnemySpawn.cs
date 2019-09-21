using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
	#region Variables 

	public GameObject[] Enemies;//1 - shooter  2-tracker  3-spammer
	public int EnemyNum;
	public Vector2 offset;

	#endregion
	
	
	#region Methods
    void Start()
    {
		offset = new Vector2(transform.position.x, transform.position.y);
		Instantiate(Enemies[EnemyNum], offset, Quaternion.identity);
    }

	#endregion
}
