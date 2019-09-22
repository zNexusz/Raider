using UnityEngine;
using UnityEngine.UI;

public class TimerUI : MonoBehaviour
{
    private GManager gManager;
    public Text min;
    public Text sec;

    
    
    // Start is called before the first frame update
    void Start()
    {
		gManager = FindObjectOfType<GManager>();
    }

    // Update is called once per frame
    void Update()
    {
        int minInt = (int)gManager.minutes;
        int secInt = (int)gManager.secounds;

        if (minInt <= 9)
        {
            min.text = "0"+minInt.ToString("0");
        }
        else
        {
            min.text = minInt.ToString("0");
        }
        
        if (secInt < 10)
        {
            sec.text = "0"+secInt.ToString("0");
        }
        else
        {
            sec.text = secInt.ToString("0");
        }
    }
}
