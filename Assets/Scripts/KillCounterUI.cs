using UnityEngine;
using UnityEngine.UI;

public class KillCounterUI : MonoBehaviour
{
	public Text Kill;
	private int KilledIngame;


	// Update is called once per frame

	void Update()
	{
        KilledIngame = FindObjectOfType<StatusCurrency>().ThisKilled;
		Kill.text = KilledIngame.ToString("0");
	}
}
