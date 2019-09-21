using UnityEngine.UI;
using UnityEngine;

public class AllMoney : MonoBehaviour
{
    public Text CoinText;

    void Update()
    {
        CoinText.text = PlayerPrefs.GetInt("5631").ToString("0");
    }
}
