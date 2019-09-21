using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelButton : MonoBehaviour
{
	public Button button;
	public Animator anim;
	private int stars;
	private int levelStar;
	//
	public string LevelName;
    public int Level;
	//
	public GameObject star1;
	public GameObject star2;
	public GameObject star3;
	//
	public bool Horrizontal = false;
	public bool Vertical = false;
	public GameObject vertical;
	public GameObject horizontal;

	void Start()
	{
		button = gameObject.GetComponent<Button>();
		ShowStars();

	}

	void Update()
	{
		if (Level <= PlayerPrefs.GetInt("LevelReached"))
		{
			anim.SetBool("Enabled", true);

            if (Horrizontal == true)
            {
                horizontal.SetActive(true);
                vertical.SetActive(false);
            }

            if (Vertical == true)
            {
                vertical.SetActive(true);
                horizontal.SetActive(false);
            }
        }
        else
        {
            anim.SetBool("Enabled", false);
            gameObject.GetComponent<Button>().interactable = false;
        }
	}

	public void ShowStars()
	{
		stars = PlayerPrefs.GetInt(LevelName + "_stars");

		if (stars == 1)
		{
			star1.SetActive(true);
			star2.SetActive(false);
			star3.SetActive(false);
		}
		if (stars == 2)
		{
			star1.SetActive(true);
			star2.SetActive(true);
			star3.SetActive(false);
		}
		if (stars == 3)
		{
			star1.SetActive(true);
			star2.SetActive(true);
			star3.SetActive(true);
		}
	}
}

