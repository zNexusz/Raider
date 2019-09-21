using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public string currentScene;
    public GManager gManager;
	//mission
	public int toKill;
	public int givenTime;
	public int limitLostHealth;
	//
	public string levelToLoad;
	public int NextLevel;
    public int ThisLevel;
	public int killed;
    public bool EndReady;

    private void Start()
    {
		killed = gManager.enemynum;
        gManager.killed = killed;
        GameObject go= GameObject.Find("GameManager");
        gManager = go.GetComponent<GManager>();
        currentScene = SceneManager.GetActiveScene().name;
        //
        if (currentScene == "Endless")
        {
            gManager.timeLimit = givenTime;
            gManager.missionHealth = 3;
            StartCoroutine(EndlessStat());
        }

		if(currentScene != "Endless")
		{
			gManager.killed = toKill;
			gManager.timeLimit = givenTime;
			gManager.missionHealth = limitLostHealth;
		}
		
	}

    public void PlayEndless()
    {
		GameObject.FindObjectOfType<AudioManager>().Play("ButtonClick");
		GameObject.Find("Fader").GetComponent<SceneFader>().FadeTo = "Endless";
        GameObject.Find("Fader").GetComponent<SceneFader>().FadeNow();
    }
    
    public IEnumerator EndlessStat()
    {
        if (currentScene == "Endless")
        {
            yield return new WaitForSeconds(0.2f);
            killed = gManager.enemynum;
            gManager.killed = killed;
            yield return new WaitForSeconds(0.2f);
            EndReady = true;
        }
    }
    
    public void lvlStars()
    {
		if (PlayerPrefs.GetInt(currentScene + "_stars") < gManager.MissionCleared && currentScene != "Endless")
		{
			PlayerPrefs.SetInt(currentScene + "_stars", gManager.MissionCleared);
			PlayerPrefs.SetInt("LevelReached", NextLevel);
		}
    }



    public void PlayLvl()
    {
        if (PlayerPrefs.GetInt("GoldenHeart") > 0)
        {
			GameObject.FindObjectOfType<AudioManager>().Play("ButtonClick");
			GameObject.Find("Fader").GetComponent<SceneFader>().FadeTo = levelToLoad;
            GameObject.Find("Fader").GetComponent<SceneFader>().FadeNow();
        }

        if (PlayerPrefs.GetInt("GoldenHeart") < 0)
        {
            GameObject.Find("TimeManager").GetComponent<TimeSystemCountDown>().ShowGetLife();
        }
    }
}
