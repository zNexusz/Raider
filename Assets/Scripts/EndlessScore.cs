using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndlessScore : MonoBehaviour
{
    public Text HighScore;
    public Text LastGameScore;
    // Start is called before the first frame update
    void Start()
    {
        HighScore.text = PlayerPrefs.GetInt("HighScore").ToString("0");
        LastGameScore.text = PlayerPrefs.GetInt("LastGameScore").ToString("0");
    }
}
