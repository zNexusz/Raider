using System.Collections;
using UnityEngine.UI;
using UnityEngine;

public class Timeruicount : MonoBehaviour
{
    private GManager gManager;
    public GameObject clock;
    public Text Secounds;
    private float startSec;
    private bool startCount;


    // Start is called before the first frame update
    void Start()
    {
		gManager = FindObjectOfType<GManager>();
        StartCoroutine(CountNow());
    }

    public IEnumerator CountNow()
    {
        yield return new WaitForSeconds(0.1f);
        startSec = gManager.timeLimit;
        Secounds.text = startSec.ToString("0");
        startCount = true;
    }
    // Update is called once per frame
    void Update()
    {
        if (startCount == true)
        {
            if (startSec > 0)
            {
                startSec -= Time.deltaTime;
                Secounds.text = startSec.ToString("0");
            }else if (startSec <= 0)
            {
                startSec = 0;
            }
        }
    }
}
