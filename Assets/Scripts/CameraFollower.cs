using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class CameraFollower : MonoBehaviour {

	public Transform target;
	public GameObject player;
	public Vector3 offset;


	// Use this for initialization
	void Start()
	{
		player = GameObject.FindGameObjectWithTag("Player");
	}
	void LateUpdate ()
	{

		player = GameObject.FindGameObjectWithTag("Player");
		target = player.transform;
        //transform.position = new Vector3(target.transform.position.x + 0.2f, target.transform.position.y + 0.3f, -1);
        transform.position = target.transform.position + offset;//camera flip

        //transform.position = new Vector3(target.transform.position.x, 0, 0) + offset; // camera x-pos

        if (player.transform.localScale.x < 0)//flips camera to -1 scale
		{
			offset.x = -1;
		}
		else
		{
			offset.x = 1;
		}
	}
	
}
