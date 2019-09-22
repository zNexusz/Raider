using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LevelGenerator : MonoBehaviour
{
	#region Variables
	
	public GameObject[] mapCollection;
	public GameObject map;
	
	#endregion
	
	#region Methods
    public void Start()
    {
	    if (SceneManager.GetActiveScene().name == "Endless")
	    {
		    map = mapCollection[Random.Range(0, mapCollection.Length)];
			Instantiate(map);
	    }
	}

    public void destroy()
    {
        StartCoroutine(reset());
    }

    IEnumerator reset()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        Destroy(player);
        GameObject map = GameObject.FindGameObjectWithTag("Level");
        Destroy(map);
        yield return new WaitForSeconds(0.2f);
		FindObjectOfType<GManager>().killed = 1;
        yield return new WaitForSeconds(0.2f);
        map = mapCollection[Random.Range(0, mapCollection.Length)];
        Instantiate(map);
    }
    #endregion
}
