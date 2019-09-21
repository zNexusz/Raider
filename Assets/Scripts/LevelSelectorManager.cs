using UnityEngine;
using UnityEngine.UI;

public class LevelSelectorManager : MonoBehaviour
{
    public GameObject ArcadeScreen;
    public GameObject EndlessScreen;
    public GameObject ShopScreen;
    //anim
    public Animator ArcadeBut;
    public Animator EndlessBut;
    public Animator ShopBut;
	//

    
    
    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.GetInt("LevelReached") == 0) PlayerPrefs.SetInt("LevelReached", 1);
        Shop();
    }

	public void Arcade()
    {
		GameObject.FindObjectOfType<AudioManager>().Play("ButtonClick");
		ArcadeScreen.SetActive(true);
        EndlessScreen.SetActive(false);
        ShopScreen.SetActive(false);
        //
        ArcadeBut.SetBool("Arcade_slide", true);
        EndlessBut.SetBool("Endless_slide", false);
        ShopBut.SetBool("Shop_slide", false);
        //
    }
    
    public void Endless()
    {
		GameObject.FindObjectOfType<AudioManager>().Play("ButtonClick");
		ArcadeScreen.SetActive(false);
        EndlessScreen.SetActive(true);
        ShopScreen.SetActive(false);
        //
        ArcadeBut.SetBool("Arcade_slide", false);
        EndlessBut.SetBool("Endless_slide", true);
        ShopBut.SetBool("Shop_slide", false);
        //
    }

    public void Shop()
    {
		GameObject.FindObjectOfType<AudioManager>().Play("ButtonClick");
		ArcadeScreen.SetActive(false);
        EndlessScreen.SetActive(false);
        ShopScreen.SetActive(true);
        //
        ArcadeBut.SetBool("Arcade_slide", false);
        EndlessBut.SetBool("Endless_slide", false);
        ShopBut.SetBool("Shop_slide", true);
        //
    }
    
    
}
