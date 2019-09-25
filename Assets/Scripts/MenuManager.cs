using UnityEngine;
using UnityEngine.SceneManagement;


public class MenuManager : MonoBehaviour
{
	public GameObject player;
	public Revivetimer revivetimer;
	public float ReviveLimit;
	public GameObject DeathMenu;
	public GameObject GameOverMenu;
	public GameObject home_but;
	public GameObject retry_but;
	public GameObject retryEnd_but;
	public GameObject next_but;
	public string currentScene;
	//
	public PlayerHealth playerHealth;
	public PlayerRespawn playerRespawn;
	public GManager gManager;
	public GameObject go;
	public GameObject gm;
	public GameObject missioncleared;
	//
	public GameObject star1;
	public GameObject star2;
	public GameObject star3;
    //
    public GameObject s1;
    public GameObject s2;
    public GameObject s3;


    public bool dead;
    //
    public Scene SceneName;

	// Start is called before the first frame update
	void Start()
    {
	    currentScene = SceneManager.GetActiveScene().name;	
		DeathMenu.SetActive(false);
		GameOverMenu.SetActive(false);
		if(currentScene == "Endless")star1.SetActive(false); star2.SetActive(false); star3.SetActive(false);
    }

	public void Dead()
	{
		GameOverMenu.SetActive(true);
		DeathMenu.SetActive(false);

		if (currentScene == "Endless")
		{
			if(playerHealth.health > 0 && dead == false)
			{
				missioncleared.SetActive(true);
			}
		}

		if (gManager.MissionCleared == 1 && currentScene != "Endless")
		{
			missioncleared.SetActive(true);
			star1.transform.gameObject.SetActive(true);
			star2.transform.gameObject.SetActive(false);
			star3.transform.gameObject.SetActive(false);
			//
			star1.SetActive(true);
			star2.SetActive(true);
			star3.SetActive(true);
		}

		if (gManager.MissionCleared == 2 && currentScene != "Endless")
		{
			missioncleared.SetActive(true);
			star1.transform.gameObject.SetActive(true);
			star2.transform.gameObject.SetActive(true);
			star3.transform.gameObject.SetActive(false);
			//
			star1.SetActive(true);
			star2.SetActive(true);
			star3.SetActive(true);
		}
		
		if (gManager.MissionCleared == 3 && currentScene != "Endless")
		{
			missioncleared.SetActive(true);
			star1.transform.gameObject.SetActive(true);
			star2.transform.gameObject.SetActive(true);
			star3.transform.gameObject.SetActive(true);
			//
			star1.SetActive(true);
			star2.SetActive(true);
			star3.SetActive(true);
		}
	}

	void Update()
  {
		go = GameObject.FindGameObjectWithTag("Player");
		gm = GameObject.Find("GameManager");
		gManager = gm.GetComponent<GManager>();
		playerHealth = go.GetComponent<PlayerHealth>();
		playerRespawn = go.GetComponent<PlayerRespawn>();
		//////////
		if (playerHealth.health < 1 && ReviveLimit > 0 && dead == false)
		{
			//Time.timeScale = 0;
			DeathMenu.SetActive(true);
		}
		if (playerHealth.health < 1 && ReviveLimit < 1 && dead == true)
		{
			//Time.timeScale = 0;
			GameOverMenu.SetActive(true);
		}

		if (dead == true)
		{
			missioncleared.SetActive(false);
			if(currentScene == "Endless")
			{
				retryEnd_but.SetActive(true);
			}
			else
			{
				retryEnd_but.SetActive(false);
			}
		}

		if (currentScene == "Endless")
		{
			home_but.SetActive(true);
			retry_but.SetActive(false);
		}
		else
		{
			home_but.SetActive(false);
			retry_but.SetActive(true);
			retryEnd_but.SetActive(false);
		}

		if(playerHealth.health > 0 && gManager.killed > 0)
		{
			DeathMenu.SetActive(false);
			GameOverMenu.SetActive(false);
		}

		if(playerHealth.health < 1 && ReviveLimit < 1)
		{
			dead = true;
			next_but.SetActive(false);
			retryEnd_but.SetActive(true);
		}
		else
		{
			if(dead == false)
			{
				next_but.SetActive(true);
				retryEnd_but.SetActive(false);
			}
		}

        if (currentScene == "Endless")
        {
            s1.SetActive(false);
            s2.SetActive(false);
            s3.SetActive(false);
        }

    }
     
	public void Revive()
	{
		playerRespawn.Respawn();
		//Time.timeScale = 1;
		revivetimer.timeLeft = 5;
		playerHealth.res();
		DeathMenu.SetActive(false);
		playerHealth.show();
		ReviveLimit -= 1;
	}

	public void Continue()
	{
		GameObject.FindObjectOfType<AudioManager>().Play("ButtonClick");

		if (currentScene == "Endless")
		{
			GameOverMenu.SetActive(false);
			GameObject.Find("LevelManager").GetComponent<LevelGenerator>().destroy();
			gManager.timeLimit = gManager.givenTime;
			StartCoroutine(GameObject.Find("UIMenu").GetComponent<Timeruicount>().CountNow());
		}
		else
		{
			LevelSelection();
		}
		GameOverMenu.SetActive(false);

		if (dead == true && currentScene != "Endless")
		{
			int Lives = PlayerPrefs.GetInt("GoldenHeart");
			Lives--;
			PlayerPrefs.SetInt("GoldenHeart", Lives);
		}
        FindObjectOfType<StatusCurrency>().SaveMoney();
	}
	
	public void LevelSelection()
	{
		//SceneManager.LoadScene(SceneName.buildIndex);  
		GameObject.Find("Fader").GetComponent<SceneFader>().FadeTo = "LevelSelector";
		GameObject.Find("Fader").GetComponent<SceneFader>().FadeNow();
        FindObjectOfType<StatusCurrency>().SaveMoney();
    }
    public void Retry()
	{
		GameObject.Find("Fader").GetComponent<SceneFader>().FadeTo = SceneManager.GetActiveScene().name;
		GameObject.Find("Fader").GetComponent<SceneFader>().FadeNow();
        FindObjectOfType<StatusCurrency>().SaveMoney();
    }
}
