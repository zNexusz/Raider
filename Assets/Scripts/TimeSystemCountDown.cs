using System;
using UnityEngine;
using UnityEngine.UI;

 [System.Serializable]
public class TimeSystemCountDown : MonoBehaviour
{
    public DateTime currentTime;
    public DateTime savedDate;
    public TimeSpan difference;
    public double diffMin;
    //
    public int Lives;
    public Text GoldenHeart;
    private int startCount;
	public int newHeart;
    //
    public Text Gheart;
    public Text NextGheart;
    public GameObject GetlifeUI;



    void Start()
    {
        long temp = Convert.ToInt64(PlayerPrefs.GetString("SavedTime"));
        savedDate = DateTime.FromBinary(temp);
        Lives = PlayerPrefs.GetInt("GoldenHeart");
	}

    void SaveTime()
    {
        long temp = Convert.ToInt64(PlayerPrefs.GetString("SavedTime"));
        savedDate = DateTime.FromBinary(temp);
    }

    // Update is called once per frame
    void Update()
    {
		newHeart = (int)diffMin / 5;
		Lives = PlayerPrefs.GetInt("GoldenHeart");
        Gheart.text = Lives.ToString("0");
        GoldenHeart.text = Lives.ToString("0");
        startCount = PlayerPrefs.GetInt("startCount");
        double min = 5 - diffMin;
        NextGheart.text = min.ToString("0");
        //
        currentTime = DateTime.Now;
        difference = currentTime.Subtract(savedDate);
        diffMin = difference.TotalMinutes;//see difference in inspector

		if (Lives < 5)
        {
            startCount = 1;
            PlayerPrefs.SetInt("startCount", startCount);
            
            if (startCount == 1)
            {
               SaveTime(); 
            }

			#region Relife

			if (newHeart >= 1 && Lives < 5)
			{
				newHeart -= 5;
				PlayerPrefs.SetString("SavedTime", DateTime.Now.ToBinary().ToString());
				//save life
				Lives += 1;
				PlayerPrefs.SetInt("GoldenHeart", Lives);
				SaveTime();
			}

			#endregion
		}

        if (Lives == 5)
        {
            startCount = 0;
            PlayerPrefs.SetInt("startCount", startCount);
            PlayerPrefs.SetString("SavedTime", DateTime.Now.ToBinary().ToString());
        }

        if (Lives <= 0)
        {
            Lives = 0;
            PlayerPrefs.SetInt("GoldenHeart", Lives);
        }
    }

    public void CloseButton()
    {
		GameObject.FindObjectOfType<AudioManager>().Play("ButtonClick");
		GetlifeUI.SetActive(false);
    }
    
    public void less()
    {
        Lives = 2;
        PlayerPrefs.SetInt("GoldenHeart", Lives);
		SaveTime();
    }
    

    public void ShowGetLife()
    {
		GameObject.FindObjectOfType<AudioManager>().Play("ButtonClick");
		GetlifeUI.SetActive(true);
    }

    public void OnAdView()
    {
		GameObject.FindObjectOfType<AudioManager>().Play("ButtonClick");
		if (Lives < 5)
        {
             startCount = 0;
             PlayerPrefs.SetInt("startCount", startCount);
             //
             PlayerPrefs.SetString("SavedTime", DateTime.Now.ToBinary().ToString());
             //save life
             Lives++;
             PlayerPrefs.SetInt("GoldenHeart", Lives); 
        }
    }
}
