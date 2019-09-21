using System.Collections;
using UnityEngine;

public class pBulletDestroy : MonoBehaviour, IPooledObjects
{
	#region Variables

	public Animator animator;
	private bool BulletStop;

	public float speed;
	public Transform player;
	public float Distance;
	public float Range=100;
	private Rigidbody2D rb;
	public Vector2 velocity=new Vector2(2,0);
	public float allowedDistance;
	private int character;


	#endregion

	#region Methods

	public void OnObjectSpawn()
	{
		gameObject.SetActive(true);
		player = GameObject.FindGameObjectWithTag("Player").transform;
		rb = GetComponent<Rigidbody2D>();

		if (player.localScale.x < 0)
		{
			speed = -5;
		}
		else
		{
			speed = 5;
		}

		character = GameObject.Find("GameManager").GetComponent<GManager>().Char;
		if (character == 1) allowedDistance = 10;
		if (character == 2) allowedDistance = 7;
		if (character == 3) allowedDistance = 4;
	}

	void Update()
	{
		player = GameObject.FindGameObjectWithTag("Player").transform;
		Distance = Vector2.Distance(transform.position, player.position);
		if(BulletStop == false)
		{
            rb.velocity = new Vector2(velocity.x * speed, 0.1965f);//0.1965 is to prevent the bullet drop.
		}
        else if(BulletStop == true)
		{
			rb.velocity = Vector3.zero;
		}

		if (Distance >= allowedDistance)
		{
			StartCoroutine(BulletShoot());
		}
	}

	private void OnTriggerEnter2D(Collider2D hitinfo)
	{
		StartCoroutine(BulletShoot());
		animator.SetBool("Impact", true);
    }

	IEnumerator BulletShoot()
	{
		///yield return new WaitForSeconds(0.1f);
		BulletStop = true;
		animator.SetBool("Impact", false);
		yield return new WaitForSeconds(0.1f);
		gameObject.SetActive(false);
		BulletStop = false;
    }

	#endregion
}
