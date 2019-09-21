using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockScript : MonoBehaviour
{

    public int health;
    public int damage;
	private Transform ThisB;
    public GameObject child;

	//public int ColorON;
	//public SpriteRenderer opacity;
	//public Transform child;
	//public float ColorChangeRate;
	

	// Update is called once per frame
	private void Start()
	{
		ThisB = gameObject.transform;
		gameObject.GetComponent<ParticleSystem>().Stop();
	}

	void Update()
    {
		if (health < 1)
		{
            StartCoroutine(Break());
		}
	}

	IEnumerator Break()
	{
        yield return new WaitForSeconds(0.01f);
		gameObject.GetComponent<BoxCollider2D>().enabled = false;
		gameObject.GetComponent<PolygonCollider2D>().enabled = false;
		gameObject.GetComponent<Renderer>().enabled = false;
        Destroy(child);
        StartCoroutine(BreakPlay());
        yield return new WaitForSeconds(0.6f);
		Destroy(gameObject);
	}

    IEnumerator BreakPlay()
    {
        gameObject.GetComponent<ParticleSystem>().Play();
        yield return new WaitForSeconds(0.5f);
        gameObject.GetComponent<ParticleSystem>().Stop();
    
    }



    void OnTriggerEnter2D(Collider2D other) {

		if (other.CompareTag("pBullet"))
		{
			health -= damage;
		}
		if (other.CompareTag("toxBullet"))
		{
			health -= damage;
			
		}
	}


	void OnTriggerStay2D(Collider2D other)
	{
		if (other.tag == "Range")
		{
			
			ThisB.parent = null;
			health = 0;
		}
	}
}
