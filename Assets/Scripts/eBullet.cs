using System.Collections;
using UnityEngine;

public class eBullet : MonoBehaviour
{
	#region Variables

	public Animator animator;
	bool BulletStop;
	public float speed;
	public Transform box;
	public Rigidbody2D rb;
	public Transform player;//enemy


	#endregion

	#region Methods

	private void Start()
	{
		gameObject.SetActive(true);
		rb = GetComponent<Rigidbody2D>();
		StartCoroutine(BulletStopTime());
	}

	void Update()
	{
		if (BulletStop == false )
		{
			//rb.velocity = Vector2.right * speed;
			transform.position = Vector2.MoveTowards(transform.position, box.position, speed * Time.deltaTime);

		}
		else
		{
			rb.velocity = Vector3.zero;
		}
		
		if(transform.position == box.position)
		{
			transform.position = player.transform.position;
			StartCoroutine(BulletShoot());
		}
	}

	private void OnTriggerEnter2D(Collider2D hitinfo)
	{
		StartCoroutine(BulletShoot());
		animator.SetBool("EImpact", true);
	}

	IEnumerator BulletStopTime()
	{
		//Debug.Log("started");
		yield return new WaitForSeconds(3);
		StartCoroutine(BulletShoot());
	}

	IEnumerator BulletShoot()
	{
		///yield return new WaitForSeconds(0.1f);
		BulletStop = true;
		animator.SetBool("EImpact", false);
		yield return new WaitForSeconds(0.1f);
		gameObject.SetActive(false);
		transform.position = player.transform.position;
		BulletStop = false;
	}

	#endregion
}
