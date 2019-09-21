using UnityEngine.UI;
using UnityEngine;

public class PotionCount : MonoBehaviour
{
    public Text HPcount;
    public Text Flashcount;
    public Text Shieldcount;

    // Update is called once per frame
    void Update()
    {
        HPcount.text = PlayerPrefs.GetInt("hp_potion_count").ToString();
        Flashcount.text = PlayerPrefs.GetInt("flash_potion_count").ToString();
        Shieldcount.text = PlayerPrefs.GetInt("shield_potion_count").ToString();
    }
}
