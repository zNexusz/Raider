using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelDifficulty : MonoBehaviour
{
	#region Variables 

	public int difficulty=1;


	#endregion


	#region Methods
	void Start()
	{

	}


	void Update()
	{

	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.CompareTag("Player"))
		{
			difficulty++;
		}
	}


	#endregion
}

