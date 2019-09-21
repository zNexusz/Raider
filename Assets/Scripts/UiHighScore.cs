using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UiHighScore : MonoBehaviour
{

    public GameObject hs;
    public Text HighscoreText;
    private GManager gManager;

    
    void Start()
    {
        if (SceneManager.GetActiveScene().name == "Endless")
        {
            hs.SetActive(true);
        }
        else
        {
            hs.SetActive(false);
        }
        gManager = GameObject.Find("GameManager").GetComponent<GManager>();
    }

    // Update is called once per frame
    void Update()
    {

        HighscoreText.text = FindObjectOfType<StatusCurrency>().ThisScore.ToString("0");
    }
}
