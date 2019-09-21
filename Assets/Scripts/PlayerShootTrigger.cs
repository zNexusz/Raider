using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShootTrigger : MonoBehaviour
{
	public Animator Anim;
	public string GunSound;
    
	public IEnumerator ShootAnim()
	{
		Anim.SetBool("ShootNow", true);
		GameObject.FindObjectOfType<AudioManager>().Play(GunSound);
		yield return new WaitForSeconds(0.1f);
		Anim.SetBool("ShootNow", false);
	}

}
