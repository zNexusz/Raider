using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GetLifeMenu : MonoBehaviour
{
	public GameObject MaxLives;
	public GameObject nextGHeart;
	public GameObject Getlifebutton;


	void Update()
    {
		if (PlayerPrefs.GetInt("GoldenHeart") < 5)
		{
			MaxLives.SetActive(false);
			nextGHeart.SetActive(true);
			Getlifebutton.SetActive(true);
		}

		if (PlayerPrefs.GetInt("GoldenHeart") == 5)
		{
			MaxLives.SetActive(true);
			nextGHeart.SetActive(false);
			Getlifebutton.SetActive(false);
		}
	}
}
