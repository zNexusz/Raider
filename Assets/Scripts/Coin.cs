using UnityEngine;
using UnityEngine.UI;


public class Coin : MonoBehaviour
{
 //   public Text CoinText;
    public Text Coins;
	public int money;

    void Update()
    {
        money = FindObjectOfType<StatusCurrency>().MoneyEarned;
        Coins.text = money.ToString("0");
    }
}
