using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneyUI : MonoBehaviour
{

	public Text CoinText;

    void Update()
    {
        
		CoinText.text = FindObjectOfType<StatusCurrency>().MoneyEarned.ToString("0");;
	}
}
