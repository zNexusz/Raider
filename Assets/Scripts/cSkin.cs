using UnityEngine;

public class cSkin : MonoBehaviour
{
	#region Variables

	Renderer rend;
	public int Char;
	public Material[] Characters;//rif 1 - bomb 2 - snip - 3 - run - 4
	public Sprite Rifler;
	public Sprite Bomber;
	public Sprite Sniper;
	public Sprite Runner;

	#endregion

	#region Methods
	void Start()
    {
		Char = PlayerPrefs.GetInt("CurrCharacter");
		rend = GetComponent<Renderer>();
		rend.enabled = true;

		if (Char == 1)
		{
			rend.sharedMaterial = Characters[1];
			this.GetComponent<SpriteRenderer>().sprite = Rifler;
		}


		if (Char == 2)
		{
			rend.sharedMaterial = Characters[2];
			this.GetComponent<SpriteRenderer>().sprite = Bomber;
		}


		if (Char == 3)
		{
			rend.sharedMaterial = Characters[3];
			this.GetComponent<SpriteRenderer>().sprite = Sniper;
		}


		if (Char == 4)
		{
			rend.sharedMaterial = Characters[4];
			this.GetComponent<SpriteRenderer>().sprite = Runner;
		}

	}
	
	#endregion
}
