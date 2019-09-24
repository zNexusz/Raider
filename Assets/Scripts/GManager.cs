using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GManager : MonoBehaviour
{
	//pick character
	public int Char;//rif 1 - exec 2 - run 3
	//
    public int health;
    public int Damage;
	public int EDamage;
	public int maxhp;
	//
	public int playerHealth; 
	//
	public int earning;
	public int kill;//gameover ui killed
	public int killed;//mission
	public int enemynum;
    //
	public float secounds;
	public float minutes;
	public float timeLimit;//mission
	public float givenTime;
	public float timer;
	//
	public int missionHealth;
	private int levelReached;
	public int MissionCleared;
	//
	public string currentScene;
	private bool EndlessMode;
	//potion
	public bool Enemyflash=false;
	public bool shield_active;
    public Text Score;
	
    void Start()
    {
		givenTime = timeLimit;
	    Time.timeScale = 1;
		PlayerPrefs.SetInt("KillCount", kill);
		Char = PlayerPrefs.GetInt("CurrCharacter");
		if (Char != 1 && Char != 2 && Char != 3) PlayerPrefs.SetInt("CurrCharacter", 1);

		currentScene = SceneManager.GetActiveScene().name;
		if (currentScene == "Endless")
		{
			EndlessMode = true;
		}

        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");//!! enemy counter

        for (int i = 0; i - 1 < enemies.Length; ++i)
        {
            PlayerPrefs.SetInt("EnemyCount", i);
            enemynum = PlayerPrefs.GetInt("EnemyCount");
        }
    }


	public void Kill()
	{
        if (enemynum >= 0)
		{
			GameObject MonyCount = GameObject.FindGameObjectWithTag("UIstuff"); // ui kill counter
			kill++;
	        killed--;
		}
       
    }

	void Update()
	{
		playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>().health;
		if (currentScene=="Endless")Score.text = FindObjectOfType<StatusCurrency>().ThisScore.ToString("0");
		Char = PlayerPrefs.GetInt("CurrCharacter");
		GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");//!! enemy counter
        
		for (int i = 0; i-1 < enemies.Length; ++i)
		{
			PlayerPrefs.SetInt("EnemyCount", i);
			enemynum = PlayerPrefs.GetInt("EnemyCount");
		}
		
		if (currentScene != "Endless" && currentScene != "LevelSelector" && currentScene != "PlayerShop")
		{
			//level timer
			//mission 
			if (killed <= 0)
			{
				MissionCleared = 1;
				MissionClear();
			}
			
		}

		if (currentScene == "Endless" && GameObject.Find("LevelManager").GetComponent<LevelManager>().EndReady == true)
		{
			killed = enemynum;
			//level time
			//mission 
			if (killed <= 0)
			{
				MissionCleared = 1;
				MissionClear();
			}
        
			//
		}
		if (killed > 0)
		{
			if (playerHealth > 0)
			{
				secounds += Time.deltaTime;
				timer += Time.deltaTime;
			}
		}
        
		if (secounds >= 60)
		{
			secounds = 0;
			minutes++;
		}	
	}

    
    void MissionClear()
    {
	    if (currentScene != "Endless")
	    {
		    if (timer < timeLimit)
		    {
			    MissionCleared++;
		    }

		    if (playerHealth > missionHealth)
		    {
			    MissionCleared++;
		    }
		    GameObject.Find("Menus").GetComponent<MenuManager>().Dead();
		    GameObject.Find("LevelManager").GetComponent<LevelManager>().lvlStars();
		    //
	    }
	    
	    if (currentScene == "Endless")
	    {
		    if (timer < timeLimit)
		    {
			    MissionCleared++;
		    }

		    if (playerHealth > missionHealth)
		    {
			    MissionCleared++;
		    }
		    GameObject.Find("Menus").GetComponent<MenuManager>().Dead();
		    GameObject.Find("LevelManager").GetComponent<LevelManager>().lvlStars();
		    //
		    int hs = PlayerPrefs.GetInt("HighScore");
		    if (FindObjectOfType<StatusCurrency>().ThisScore > hs)
		    {
			    PlayerPrefs.SetInt("HighScore", FindObjectOfType<StatusCurrency>().ThisScore);
		    }
		    PlayerPrefs.SetInt("LastGameScore", FindObjectOfType<StatusCurrency>().ThisScore);
	    }
        if (FindObjectOfType<LevelManager>().ThisLevel >= PlayerPrefs.GetInt("LevelReached")) PlayerPrefs.SetInt("LevelReached", GameObject.FindObjectOfType<LevelManager>().NextLevel);

    }

	public void Stats()
	{
		if (Char == 1)
		{
			health = 4;
			Damage = 1; 
			EDamage = 1;
			maxhp = 4;
		}

		if (Char == 2)
		{
			health = 3;
			Damage = 1; 
			EDamage = 2;
			maxhp = 3;
		}

		if (Char == 3)
		{
			health = 2;
			Damage = 1; 
			EDamage = 1;
			maxhp = 2;
		}
	}

	public void Rifler()
	{
		Char = 1;
		PlayerPrefs.SetInt("CurrCharacter", Char);
	}
	
	public void Executioner()
	{
		Char = 2;
		PlayerPrefs.SetInt("CurrCharacter", Char);
	}
	
	public void Runner()
	{
		Char = 3;
		PlayerPrefs.SetInt("CurrCharacter", Char);
	}

	public void Hp_potion()
	{
		GameObject.FindWithTag("Player").GetComponent<PlayerGranade>().HPpotion();
	}
	
	public void Flash_potion()
	{
		GameObject.FindWithTag("Player").GetComponent<PlayerGranade>().Flashpotion();
	}
	
	public void Shield_potion()
	{
		GameObject.FindWithTag("Player").GetComponent<PlayerGranade>().Shieldpotion();
	}
	
}
