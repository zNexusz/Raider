using UnityEngine;
using UnityEngine.Advertisements;

public class AdManager : MonoBehaviour
{
    // Start is called before the first frame update
    public void ShowAdGH()
    {
		if (Advertisement.IsReady())
		{
			Advertisement.Show("rewardedVideo", new ShowOptions() {resultCallback = AdOutcome});
		}
    }

	void AdOutcome(ShowResult result)
    {
		switch (result)
		{
			case ShowResult.Finished:
				GameObject.FindObjectOfType<TimeSystemCountDown>().OnAdView();
				break;
			case ShowResult.Failed:
				break;
		}
    }

	public void ShowAdRevive()
	{
		if (Advertisement.IsReady())
		{
			Advertisement.Show("rewardedVideo", new ShowOptions() { resultCallback = AdRevive});
		}
	}

	void AdRevive(ShowResult result)
	{
		switch (result)
		{
			case ShowResult.Finished:
				GameObject.FindObjectOfType<MenuManager>().Revive();
				GameObject.FindObjectOfType<MenuManager>().DeathMenu.SetActive(false);
				break;
			case ShowResult.Failed:
				GameObject.FindObjectOfType<MenuManager>().DeathMenu.SetActive(false);
				GameObject.FindObjectOfType<MenuManager>().GameOverMenu.SetActive(false);
				break;
		}
	}

}
