using UnityEngine;

public class PlayerSpawnPlat : MonoBehaviour
{
	public GameObject Rifler;//1
	public GameObject Executioner;//2
	public GameObject Runner;//3
	public Vector3 offset;
	public int Char;

	void Start()
	{
		Char = PlayerPrefs.GetInt("CurrCharacter");
		//////////////////
		///
		if (Char == 1)
		{
			Instantiate(Rifler,transform.position + offset,Quaternion.identity);
		}


		if (Char == 2)
		{
			Instantiate(Executioner,transform.position + offset,Quaternion.identity);
		}

		if (Char == 3)
		{
			Instantiate(Runner,transform.position + offset,Quaternion.identity);
		}
	}
}

