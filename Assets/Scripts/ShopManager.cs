using UnityEngine;
using UnityEngine.UI;


public class ShopManager : MonoBehaviour
{
    public Animator potionInfo;
    public Animator char1;
    public Animator char2;
    public Animator char3;
    public int character;
    public Animator Hp_but;
    public Animator Flash_but;
    public Animator Shield_but;
    //
    public Text HPcount;
    public Text Flashcount;
    public Text Shieldcount;
	//money flash
	public Animator money;
    
    
    void flashMoneyNow()
	{
		money.SetTrigger("flashMoney");
	}
    // Start is called before the first frame update
    void Update()
    {
        character = PlayerPrefs.GetInt("CurrCharacter");
        if(PlayerPrefs.GetInt("CurrCharacter") == 1)
		{
			char1.SetBool("Equipped", true);
			char2.SetBool("Equipped", false);
			char3.SetBool("Equipped", false);
		}
        if(PlayerPrefs.GetInt("CurrCharacter") == 2)
		{
			char1.SetBool("Equipped", false);
			char2.SetBool("Equipped", true);
			char3.SetBool("Equipped", false);
		}
        if(PlayerPrefs.GetInt("CurrCharacter") == 3)
		{
			char1.SetBool("Equipped", false);
			char2.SetBool("Equipped", false);
			char3.SetBool("Equipped", true);
		}
        //
        HPcount.text = PlayerPrefs.GetInt("hp_potion_count").ToString();
        Flashcount.text = PlayerPrefs.GetInt("flash_potion_count").ToString();
        Shieldcount.text = PlayerPrefs.GetInt("shield_potion_count").ToString();
        //
        int shield = PlayerPrefs.GetInt("shield_potion_count");
        if (shield == 5)
        {
            Shield_but.SetBool("max", true);
        }
        //
        int flash = PlayerPrefs.GetInt("flash_potion_count");
        if (flash == 5)
        {
            Flash_but.SetBool("max", true);
        }
        //
        int HP = PlayerPrefs.GetInt("hp_potion_count");
        if (HP == 5)
        {
            Hp_but.SetBool("max", true);
        }
    }

    // Update is called once per frame
    public void selectChar1()
    {
		GameObject.FindObjectOfType<AudioManager>().Play("ButtonClick");
		PlayerPrefs.SetInt("CurrCharacter", 1);
        char1.SetBool("Equipped", true);
        char2.SetBool("Equipped", false);
        char3.SetBool("Equipped", false);
    }
    
    public void selectChar2()
    {
		GameObject.FindObjectOfType<AudioManager>().Play("ButtonClick");
		PlayerPrefs.SetInt("CurrCharacter", 2);
        char1.SetBool("Equipped", false);
        char2.SetBool("Equipped", true);
        char3.SetBool("Equipped", false);
    }
    
    public void selectChar3()
    {
		GameObject.FindObjectOfType<AudioManager>().Play("ButtonClick");
		PlayerPrefs.SetInt("CurrCharacter", 3);
        char1.SetBool("Equipped", false);
        char2.SetBool("Equipped", false);
        char3.SetBool("Equipped", true);
    }

    public void BuyHP()
    {
		GameObject.FindObjectOfType<AudioManager>().Play("ButtonClick");
		if (PlayerPrefs.GetInt("5631") >= 300)
        {
            int HP = PlayerPrefs.GetInt("hp_potion_count");
            
            if (HP < 5)
            {
                Hp_but.SetBool("max", false);
                HP++;
                PlayerPrefs.SetInt("hp_potion_count", HP);
                //
                int money = PlayerPrefs.GetInt("5631");
                money -= 300;
                PlayerPrefs.SetInt("5631", money);
            }

            if (HP == 5)
            {
                Hp_but.SetBool("max", true);
            }
        }else if(PlayerPrefs.GetInt("5631") < 300)
		{
			flashMoneyNow();
		}
    }
    
    
    public void BuyFlash()
    {
		GameObject.FindObjectOfType<AudioManager>().Play("ButtonClick");
		if (PlayerPrefs.GetInt("5631") >= 200)
        {
            int flash = PlayerPrefs.GetInt("flash_potion_count");
            
            if (flash < 5)
            {
                Flash_but.SetBool("max", false);
                flash++;
                PlayerPrefs.SetInt("flash_potion_count", flash);
                //
                int money = PlayerPrefs.GetInt("5631");
                money -= 200;
                PlayerPrefs.SetInt("5631", money);
            }

            if (flash == 5)
            {
                Flash_but.SetBool("max", true);
            }
        }
		else if (PlayerPrefs.GetInt("5631") < 300)
		{
			flashMoneyNow();
		}
	}
    
    public void BuyShield()
    {
		GameObject.FindObjectOfType<AudioManager>().Play("ButtonClick");
		if (PlayerPrefs.GetInt("5631") >= 400)
        {
            int shield = PlayerPrefs.GetInt("shield_potion_count");
            
            if (shield < 5)
            {
                Shield_but.SetBool("max", false);
                shield++;
                PlayerPrefs.SetInt("shield_potion_count", shield);
                //
                int money = PlayerPrefs.GetInt("5631");
                money -= 400;
                PlayerPrefs.SetInt("5631", money);
            }

            if (shield == 5)
            {
                Shield_but.SetBool("max", true);
            }
        }
		else if (PlayerPrefs.GetInt("5631") < 300)
		{
			flashMoneyNow();
		}
	}

    public void PotionInfo()
    {
		GameObject.FindObjectOfType<AudioManager>().Play("ButtonClick");
		potionInfo.SetBool("show_info", true);
    }
    
    public void HidePotionInfo()
    {
		potionInfo.SetBool("show_info", false);
    }
}
