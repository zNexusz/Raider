using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayLevel : MonoBehaviour
{
	public string ThisLevel;
    void Start()
    {
		ThisLevel = gameObject.name;
    }

    // Update is called once per frame
    public void PlayThisLevel()
    {
		GameObject.FindObjectOfType<LevelManager>().levelToLoad = ThisLevel;
		GameObject.FindObjectOfType<LevelManager>().PlayLvl(); 
    }
}
