using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGranade : MonoBehaviour {

	#region Variables

	public Transform player;
	private Rigidbody2D rb;
	public int limit=5;
	ObjectPooler objectPooler;
	public Vector3 offset = new Vector3(0, 0.2f, 0);
	//
	public GameObject flash;
	public GameObject shield_potion;
	public GameObject health_potion;
	//
	private int hp_count;
	private int healed;
	private int flash_count;
	private int shield_count;
	//
	public GameObject shield;
	private bool useShield;


	#endregion


	#region Methods

	void Start()
	{
		objectPooler = ObjectPooler.Instance;
		rb = GetComponent<Rigidbody2D>();
	}


	// Update is called once per frame
	void Update()
	{
		hp_count = PlayerPrefs.GetInt("hp_potion_count");
		flash_count = PlayerPrefs.GetInt("flash_potion_count");
		shield_count = PlayerPrefs.GetInt("shield_potion_count");
		//
		rb.freezeRotation = true;
	}

	public void HPpotion()
	{
		healed = 0;
		if(hp_count>0)hp_count--;
		PlayerPrefs.SetInt("hp_potion_count", hp_count);
		if(hp_count>0) Instantiate(health_potion, player.position, Quaternion.identity);
		
		if (hp_count> 0 && gameObject.GetComponent<PlayerHealth>().health <= GameObject.Find("GameManager").GetComponent<GManager>().maxhp && healed < 3)
		{
			healed++;
			gameObject.GetComponent<PlayerHealth>().health++;
		}
	}

    public void ThrowNade()
    {
        if (limit > 0)
        {
            Throw();
            limit--;
        }
    }
	
	public void Flashpotion()
	{
		if(flash_count>0)flash_count--;
		PlayerPrefs.SetInt("flash_potion_count",flash_count);
		if(flash_count>0) Instantiate(flash, player.position, Quaternion.identity);
	}
	
	public void Shieldpotion()
	{
		if (useShield == false)
		{
			if(shield_count>0)shield_count--;
			PlayerPrefs.SetInt("shield_potion_count", shield_count);
			if(shield_count>0) Instantiate(shield_potion, player.position, Quaternion.identity);
			StartCoroutine(ShieldON());
		}
	}

	public IEnumerator ShieldON()
	{
		useShield = true;
		shield.SetActive(true);
		GameObject.FindObjectOfType<AudioManager>().Play("Shield_potion");
		GameObject.Find("GameManager").GetComponent<GManager>().Damage = 0;
		yield return new WaitForSeconds(5);
		shield.SetActive(false);
		GameObject.Find("GameManager").GetComponent<GManager>().Damage = 1;
		useShield = false;
	}
	

	void Throw()
	{
		objectPooler.SpawnFromPool("Granade", transform.position + offset, Quaternion.identity);
	}

	#endregion
}
