using UnityEngine;


public class HealthUI : MonoBehaviour
{
	public Animator Heart1;
	public Animator Heart2;
	public Animator Heart3;
	public Animator Heart4;
	//
    private bool char1;
    private bool char2;
    private bool char3;
    //
    public int character;
	public int playerHealth;


	private void Start()
	{
	}

	void Update()
    {
	    playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>().health;
	    character = GameObject.Find("GameManager").GetComponent<GManager>().Char;
		
	    if (character == 1) char1 = true;
	    if (character == 2) char2 = true;
	    if (character == 3) char3 = true;
	    //
	    if (char1 == true)
	    {
		    Heart1.gameObject.SetActive(true);
		    Heart2.gameObject.SetActive(true);
		    Heart3.gameObject.SetActive(true);
		    Heart4.gameObject.SetActive(true);
		    if (playerHealth <= 0)
		    {
			    Heart1.SetBool("change", true);
			    Heart2.SetBool("change", true);
			    Heart3.SetBool("change", true);
			    Heart4.SetBool("change", true);
		    }

		    if (playerHealth == 1)
		    {
			    Heart1.SetBool("change", false);
			    Heart2.SetBool("change", true);
			    Heart3.SetBool("change", true);
			    Heart4.SetBool("change", true);
		    }

		    if (playerHealth == 2)
		    {
			    Heart1.SetBool("change", false);
			    Heart2.SetBool("change", false);
			    Heart3.SetBool("change", true);
			    Heart4.SetBool("change", true);
		    }

		    if (playerHealth == 3)
		    {
			    Heart1.SetBool("change", false);
			    Heart2.SetBool("change", false);
			    Heart3.SetBool("change", false);
			    Heart4.SetBool("change", true);
		    }
		    
		    if (playerHealth == 4)
		    {
			    Heart1.SetBool("change", false);
			    Heart2.SetBool("change", false);
			    Heart3.SetBool("change", false);
			    Heart4.SetBool("change", false);
		    }
	    }

	    if (char2 == true)
	    {
		    Heart1.gameObject.SetActive(true);
		    Heart2.gameObject.SetActive(true);
		    Heart3.gameObject.SetActive(true);
		    Heart4.gameObject.SetActive(false);
		    
		    if (playerHealth <= 0)
		    {
			    Heart1.SetBool("change", true);
			    Heart2.SetBool("change", true);
			    Heart3.SetBool("change", true);
		    }

		    if (playerHealth == 1)
		    {
			    Heart1.SetBool("change", false);
			    Heart2.SetBool("change", true);
			    Heart3.SetBool("change", true);
		    }

		    if (playerHealth == 2)
		    {
			    Heart1.SetBool("change", false);
			    Heart2.SetBool("change", false);
			    Heart3.SetBool("change", true);
		    }

		    if (playerHealth == 3)
		    {
			    Heart1.SetBool("change", false);
			    Heart2.SetBool("change", false);
			    Heart3.SetBool("change", false);
		    }
	    }
	    
	    if (char3 == true)
	    {
		    Heart1.gameObject.SetActive(true);
		    Heart2.gameObject.SetActive(true);
		    Heart3.gameObject.SetActive(false);
		    Heart4.gameObject.SetActive(false);
		    
		    if (playerHealth <= 0)
		    {
			    Heart1.SetBool("change", true);
			    Heart2.SetBool("change", true);
		    }

		    if (playerHealth == 1)
		    {
			    Heart1.SetBool("change", false);
			    Heart2.SetBool("change", true);
		    }

		    if (playerHealth == 2)
		    {
			    Heart1.SetBool("change", false);
			    Heart2.SetBool("change", false);
		    }
	    }
    }
}
