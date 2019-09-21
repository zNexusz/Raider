using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDestroy : MonoBehaviour
{
	public Animator animator;
	bool BulletStop;
	public float speed;
	private Transform player;
	private Vector2 target;



	void Start()
	{
		player = GameObject.FindGameObjectWithTag("Player").transform;
		target = new Vector2(player.position.x, player.position.y);

	}

	void Update()
	{
		if (BulletStop == false)
		{
			transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);

			/*if (transform.position.x == target.x && transform.position.y == target.y)
			{
				gameObject.SetActive(false);
			}*/
		}else if(BulletStop == true)
		{
			GetComponent<Rigidbody2D>().velocity = Vector3.zero;
		}
	}

	private void OnTriggerEnter2D(Collider2D hitinfo)
	{
		if (hitinfo.CompareTag("Player"))
		{

			StartCoroutine(BulletShoot());
			animator.SetBool("EImpact", true);
		}

		if (hitinfo.CompareTag("Enemy"))
		{

			StartCoroutine(BulletShoot());
			animator.SetBool("EImpact", true);
		}

	}

	IEnumerator BulletShoot()
	{
		///yield return new WaitForSeconds(0.1f);
		BulletStop = true;
		animator.SetBool("EImpact", false);
		yield return new WaitForSeconds(0.1f);
		gameObject.SetActive(false);
		BulletStop = false;
	}
}

