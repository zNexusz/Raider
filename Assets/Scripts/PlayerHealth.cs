using UnityEngine;
using System.Collections.Generic;
using System.Collections;



public class PlayerHealth : MonoBehaviour
{
	#region Variables

	public int damage;
	public int health;
	public GManager gManager;
	public GameObject go;
	public Renderer rend;
	int Char;
	public int diff;


	#endregion
	#region Methods

	private void Start()
	{
		Char = PlayerPrefs.GetInt("CurrCharacter");
		FindObjectOfType<GManager>().Stats();
	}
	void Update()
	{
		go = GameObject.Find("GameManager");
		gManager = go.GetComponent<GManager>();
		rend = GetComponent<Renderer>();
		rend.enabled = true;

		damage = gManager.Damage;
		health = gManager.health;

		if (gManager.health <= 0)
		{
			gManager.health = 0;
			rend.enabled = false;
			//
			gameObject.GetComponent<PlayerMovement>().enabled = false;
			gameObject.GetComponent<PlayerGranade>().enabled = false;
			gameObject.GetComponent<Shootbullet>().enabled = false;
		}
		else
		{
			gameObject.GetComponent<PlayerMovement>().enabled = true;
			gameObject.GetComponent<PlayerGranade>().enabled = true;
			gameObject.GetComponent<Shootbullet>().enabled = true;
		}

		if (gManager.health < 1 && gManager.shield_active == true)
		{
			res();
		}
	}

	public void show()
	{
		rend.enabled = true;
	}

	public void res()
	{
        StartCoroutine(FindObjectOfType<PlayerGranade>().ShieldON());

        if (Char == 1)
		{
			gManager.health += 4;
		}

		if (Char == 2)
		{
			gManager.health += 3;
		}

		if (Char == 3)
		{
			gManager.health += 2;
		}
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (gManager.health > 0)
		{
			if (other.CompareTag("Bullet"))
			{
				gManager.health -= gManager.Damage;
			}

			if (other.CompareTag("eBullet"))
			{
				gManager.health -= gManager.Damage;
			}
		}

		if (other.CompareTag("DeathBlock"))
		{
			gManager.health -= gManager.health;
		}

	}

	#endregion
}
