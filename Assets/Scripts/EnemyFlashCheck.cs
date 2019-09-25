
using UnityEngine;

public class EnemyFlashCheck : MonoBehaviour
{
	public GameObject img;
    void Update()
    {
        if(FindObjectOfType<GManager>().Enemyflash == false)
		{
			img.SetActive(false);
		}
		else
		{
			img.SetActive(true);
		}
    }
}
