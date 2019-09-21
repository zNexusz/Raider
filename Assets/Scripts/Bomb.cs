using System.Collections;
using UnityEngine;

public class Bomb : MonoBehaviour, IPooledObjects
{

#region Variables


	private Rigidbody2D rb;
	public float speed=2;
	public Transform player;
	public BombRange bombRange;
	public Animator animator;

	#endregion


	#region Methods
	

	public void OnObjectSpawn()
	{   
	//	bombRange.Stop();
		rb = GetComponent<Rigidbody2D>();
		StartCoroutine(Insta());
		player = GameObject.FindGameObjectWithTag("Player").transform;
		Throw();
	}

	private void Start()
	{
		player = GameObject.FindGameObjectWithTag("Player").transform;
		rb = GetComponent<Rigidbody2D>();
		StartCoroutine(Insta());
	}

	IEnumerator Ignite()
	{
		yield return new WaitForSeconds(1f);
		animator.SetTrigger("Ignite");
		StartCoroutine(explosionSound());
		if (bombRange.Exploded == true)
		{
			StartCoroutine(bStop());
		}
	}

	IEnumerator explosionSound()
	{
		yield return new WaitForSeconds(1.6f);
		GameObject.FindObjectOfType<AudioManager>().Play("Explosion");
	}
	IEnumerator bStop()
	{
		yield return new WaitForSeconds(1.5f);
		gameObject.SetActive(false);
	}

	IEnumerator Insta()
	{
		yield return new WaitForSeconds(5f);
		gameObject.SetActive(false);
	}

	void Throw()
	{
		speed = 2;
		if (player.localScale.x < 0)
		{
			gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(-2,2)*speed;
		}else
		{
			gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(2,2)*speed;
		}
		StartCoroutine(Ignite());
	}


	#endregion
}
