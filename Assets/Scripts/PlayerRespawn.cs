using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRespawn : MonoBehaviour
{
	public Vector2 respawnPoint;
	public Vector2 offset;
    private float diff;//for a non constant changing spawn point

	public void Respawn()
    {
		transform.position = respawnPoint + offset;
    }

    private void Update()
    {
        diff = respawnPoint.x - transform.position.x;
        if (FindObjectOfType<PlayerMovement>().isGrounded == true)
		{
            if(diff > 1 || diff < -1)
            {
                respawnPoint = transform.position;
            }

		}
    }
}
